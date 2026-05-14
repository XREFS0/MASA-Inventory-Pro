using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using inventory.Helpers;

namespace inventory.Presentation
{
    public partial class DashboardForm : Form
    {
        private string imagePath = Path.Combine(Application.StartupPath, "Assets", "Images");
        private BLL.DashboardService _dashboardService = new BLL.DashboardService();
        private DAL.SalesRepository _salesRepo = new DAL.SalesRepository();

        public DashboardForm()
        {
            InitializeComponent();
            SetupAdvancedUI(); // Add new UI elements
            SetTags();
            LoadIcons();
            LoadStats();
            ApplyUI();
            StartClock();
        }

        private Label lblGreeting;
        private Label lblClock;

        private void SetupAdvancedUI()
        {
            // 1. Greeting
            lblGreeting = new Label {
                Text = "مرحباً بك مجدداً، أيها المدير!",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 10),
                AutoSize = true
            };
            this.Controls.Add(lblGreeting);
            lblGreeting.BringToFront();

            // 2. Clock
            lblClock = new Label {
                Text = DateTime.Now.ToString("HH:mm:ss"),
                Font = new Font("Segoe UI Semibold", 12),
                ForeColor = ThemeManager.DarkSubText,
                Location = new Point(850, 15),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            this.Controls.Add(lblClock);

            // Adjust cards and charts position
            foreach (Control c in this.Controls) {
                if (c != null && c.Name != null && (c.Name.StartsWith("card") || c.Name.StartsWith("panelChart"))) c.Top += 30;
            }
            
            // Expand charts height
            panelChart1.Height += 120;
            panelChart2.Height += 120;

            // Hide old elements
            lblTableTitle.Visible = false;
            dgvRecentActivity.Visible = false;
        }

        private void StartClock()
        {
            Timer t = new Timer { Interval = 1000 };
            t.Tick += (s, e) => {
                lblClock.Text = DateTime.Now.ToString("HH:mm:ss") + " | " + DateTime.Now.ToString("ddd, MMM dd");
            };
            t.Start();
        }

        private void LoadIcons()
        {
            try
            {
                string path = Application.StartupPath;
                while (!Directory.Exists(Path.Combine(path, "Assets")) && path.Length > 3)
                {
                    path = Path.GetDirectoryName(path);
                }
                string imagePath = Path.Combine(path, "Assets", "Images");

                SetIcon(pbIcon1, Path.Combine(imagePath, "Products.png"));
                SetIcon(pbIcon2, Path.Combine(imagePath, "LowStock.png"));
                SetIcon(pbIcon3, Path.Combine(imagePath, "TotalSales.png"));
                SetIcon(pbIcon4, Path.Combine(imagePath, "RecentOrders.png"));
            }
            catch { }
        }

        private void SetIcon(Guna.UI2.WinForms.Guna2PictureBox pb, string fullPath)
        {
            if (File.Exists(fullPath))
            {
                pb.Image = Image.FromFile(fullPath);
            }
        }

        private void SetTags()
        {
            lblTableTitle.Tag = "Dashboard";
            // Map cards if they have labels
        }

        private void ApplyUI()
        {
            Helpers.ThemeManager.ApplyTheme(this);
            Helpers.LanguageManager.ApplyLanguage(this);
        }

        private void LoadStats()
        {
            try {
                var stats = _dashboardService.GetDashboardStats();
                lblVal1.Text = stats.TotalProducts.ToString("N0");
                lblVal2.Text = stats.LowStockCount.ToString("N0");
                string currency = " EGP";
                lblVal3.Text = stats.TotalSales.ToString("N0") + currency;
                lblVal4.Text = stats.RecentOrders.ToString("N0");

                if (stats.LowStockCount > 0)
                {
                    (this.ParentForm as MainForm)?.ShowNotification("Low Stock Alert", $"You have {stats.LowStockCount} items running low on stock!", ToolTipIcon.Warning);
                }

                dgvRecentActivity.DataSource = null;
                dgvRecentActivity.Columns.Clear();
                
                dgvRecentActivity.DataSource = _dashboardService.GetRecentActivity();
                
                // Load Icons
                string assetsPath = Path.Combine(Application.StartupPath, "Assets", "Images");
                if (!Directory.Exists(assetsPath))
                {
                    string path = Application.StartupPath;
                    while (!Directory.Exists(Path.Combine(path, "Assets")) && path.Length > 3)
                        path = Path.GetDirectoryName(path);
                    assetsPath = Path.Combine(path, "Assets", "Images");
                }

                Image editImg = File.Exists(Path.Combine(assetsPath, "Edit.png")) ? Image.FromFile(Path.Combine(assetsPath, "Edit.png")) : null;
                Image deleteImg = File.Exists(Path.Combine(assetsPath, "Delete.png")) ? Image.FromFile(Path.Combine(assetsPath, "Delete.png")) : null;

                // Add Action Columns Safely
                if (dgvRecentActivity.Columns.Contains("Edit")) dgvRecentActivity.Columns.Remove("Edit");
                DataGridViewImageColumn editBtn = new DataGridViewImageColumn {
                    Name = "Edit",
                    Image = editImg,
                    HeaderText = "",
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                editBtn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRecentActivity.Columns.Add(editBtn);

                if (dgvRecentActivity.Columns.Contains("Delete")) dgvRecentActivity.Columns.Remove("Delete");
                DataGridViewImageColumn deleteBtn = new DataGridViewImageColumn {
                    Name = "Delete",
                    Image = deleteImg,
                    HeaderText = "",
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                deleteBtn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRecentActivity.Columns.Add(deleteBtn);

                if (dgvRecentActivity.Columns.Contains("Id")) dgvRecentActivity.Columns["Id"].Visible = false;
                
                dgvRecentActivity.RowTemplate.Height = 55;
                dgvRecentActivity.AllowUserToResizeRows = false;

                dgvRecentActivity.CellContentClick -= dgvRecentActivity_CellContentClick;
                dgvRecentActivity.CellContentClick += dgvRecentActivity_CellContentClick;

                ApplyUI();
                
                // Draw real charts
                DrawSalesChart(panelChart1);
                DrawStockChart(panelChart2);
            } catch {
                // Silently handle or log
            }
        }

        private void dgvRecentActivity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int activityId = Convert.ToInt32(dgvRecentActivity.Rows[e.RowIndex].Cells["Id"].Value);
            string type = dgvRecentActivity.Rows[e.RowIndex].Cells["Type"].Value.ToString();

            if (dgvRecentActivity.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (type == "Sale")
                {
                    if (MessageBox.Show("هل أنت متأكد من حذف هذا الطلب؟ سيتم استعادة الكميات إلى المخزن.", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (_salesRepo.DeleteSale(activityId))
                        {
                            LoadStats();
                        }
                    }
                }
            }
            else if (dgvRecentActivity.Columns[e.ColumnIndex].Name == "Edit")
            {
                using (var editForm = new Popups.AddSaleForm(activityId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadStats();
                    }
                }
            }
        }

        private void DrawSalesChart(Panel p)
        {
            p.Controls.Clear();
            try {
                var salesData = _dashboardService.GetMonthlySalesData();
                int maxVal = salesData.Values.Count > 0 ? salesData.Values.Max() : 1;
                if(maxVal == 0) maxVal = 1;

                int startX = 60;
                int gap = 55;
                int i = 0;
                
                // Title
                Label lblChartTitle = new Label {
                    Text = "الإيرادات الشهرية (ج.م)",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(15, 15),
                    AutoSize = true
                };
                p.Controls.Add(lblChartTitle);

                foreach(var entry in salesData)
                {
                    int barHeight = (int)((double)entry.Value / maxVal * (p.Height - 100));
                    Guna.UI2.WinForms.Guna2GradientPanel bar = new Guna.UI2.WinForms.Guna2GradientPanel();
                    bar.FillColor = Color.FromArgb(140, 82, 255);
                    bar.FillColor2 = Color.FromArgb(64, 123, 255);
                    bar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                    bar.BorderRadius = 6;
                    bar.Size = new Size(30, barHeight);
                    bar.Location = new Point(startX + (i * gap), p.Height - barHeight - 45);
                    
                    // Value Tooltip (simplified as label)
                    Label lblVal = new Label {
                        Text = entry.Value >= 1000 ? (entry.Value/1000.0).ToString("N1") + "k" : entry.Value.ToString(),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 7, FontStyle.Bold),
                        Location = new Point(startX + (i * gap) - 5, p.Height - barHeight - 65),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Width = 40
                    };
                    p.Controls.Add(lblVal);
                    p.Controls.Add(bar);

                    Label lbl = new Label {
                        Text = entry.Key,
                        ForeColor = ThemeManager.DarkSubText,
                        Font = new Font("Segoe UI Semibold", 8),
                        Location = new Point(startX + (i * gap) - 2, p.Height - 40),
                        AutoSize = true
                    };
                    p.Controls.Add(lbl);
                    i++;
                    if (i > 6) break;
                }
            } catch { }
        }

        private void DrawStockChart(Panel p)
        {
            p.Controls.Clear();
            try {
                var stockData = _dashboardService.GetStockCategoryData();
                int i = 0;
                int startY = 60;
                
                Label lblChartTitle = new Label {
                    Text = "المخزون حسب الصنف",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(15, 15),
                    AutoSize = true
                };
                p.Controls.Add(lblChartTitle);

                foreach(var entry in stockData)
                {
                    Label lbl = new Label {
                        Text = entry.Key,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 9),
                        Location = new Point(25, startY + (i * 38)),
                        AutoSize = true
                    };
                    p.Controls.Add(lbl);

                    Guna.UI2.WinForms.Guna2ProgressBar pb = new Guna.UI2.WinForms.Guna2ProgressBar();
                    pb.Size = new Size(p.Width - 180, 12);
                    pb.Location = new Point(140, startY + (i * 38) + 5);
                    pb.Value = entry.Value > 100 ? 100 : entry.Value * 10; // Scaling for effect
                    pb.FillColor = Color.FromArgb(25, 29, 43);
                    pb.ProgressColor = Color.FromArgb(46, 204, 113);
                    pb.ProgressColor2 = Color.FromArgb(22, 160, 133);
                    pb.BorderRadius = 6;
                    p.Controls.Add(pb);
                    
                    Label lblCount = new Label {
                        Text = entry.Value.ToString() + " قطعة",
                        ForeColor = ThemeManager.DarkSubText,
                        Font = new Font("Segoe UI", 8),
                        Location = new Point(p.Width - 55, startY + (i * 38) + 2),
                        AutoSize = true
                    };
                    p.Controls.Add(lblCount);

                    i++;
                    if(i > 4) break;
                }
            } catch { }
        }

    }
}
