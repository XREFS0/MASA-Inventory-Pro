using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace inventory.Presentation
{
    public partial class SalesForm : Form
    {
        private DAL.SalesRepository _salesRepo = new DAL.SalesRepository();

        public SalesForm()
        {
            InitializeComponent();
            SetTags();
            RefreshData();
            ApplyUI();
        }

        private void SetTags()
        {
            lblTitle.Tag = "Orders";
            btnNewSale.Tag = "NewOrder";
            btnEditSale.Tag = "Edit";
            btnDeleteSale.Tag = "Delete";
            // Map labels for stats
        }

        private void ApplyUI()
        {
            Helpers.ThemeManager.ApplyTheme(this);
            Helpers.LanguageManager.ApplyLanguage(this);
        }

        public void RefreshData()
        {
            LoadData();
            LoadStatistics();
        }

        private void LoadData()
        {
            try {
                dgvSales.DataSource = null;
                dgvSales.Columns.Clear();
                
                DataTable dt = _salesRepo.GetAllSales();
                dgvSales.DataSource = dt;
                
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
                if (dgvSales.Columns.Contains("Edit")) dgvSales.Columns.Remove("Edit");
                DataGridViewImageColumn editBtn = new DataGridViewImageColumn {
                    Name = "Edit",
                    Image = editImg,
                    HeaderText = "",
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                editBtn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvSales.Columns.Add(editBtn);

                if (dgvSales.Columns.Contains("Delete")) dgvSales.Columns.Remove("Delete");
                DataGridViewImageColumn deleteBtn = new DataGridViewImageColumn {
                    Name = "Delete",
                    Image = deleteImg,
                    HeaderText = "",
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                deleteBtn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvSales.Columns.Add(deleteBtn);

                if (dgvSales.Columns.Contains("DeleteAll")) dgvSales.Columns.Remove("DeleteAll");
                DataGridViewImageColumn deleteAllBtn = new DataGridViewImageColumn {
                    Name = "DeleteAll",
                    Image = deleteImg, 
                    HeaderText = "",
                    Width = 50,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                deleteAllBtn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvSales.Columns.Add(deleteAllBtn);

                if (dgvSales.Columns.Contains("Id")) dgvSales.Columns["Id"].Visible = false;
                
                dgvSales.RowTemplate.Height = 55;
                dgvSales.AllowUserToResizeRows = false;
                if (dgvSales.Columns.Contains("TotalAmount"))
                    dgvSales.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";
                if (dgvSales.Columns.Contains("GrandTotal"))
                    dgvSales.Columns["GrandTotal"].DefaultCellStyle.Format = "N2";
                
                dgvSales.CellContentClick -= dgvSales_CellContentClick;
                dgvSales.CellContentClick += dgvSales_CellContentClick;
                
                dgvSales.CellPainting -= Helpers.ThemeManager.DrawActionButtons;
                dgvSales.CellPainting += Helpers.ThemeManager.DrawActionButtons;

                ApplyUI();
                dgvSales.DataBindingComplete += (s, ev) => {
                    dgvSales.ClearSelection();
                    dgvSales.CurrentCell = null;
                };
            } catch (Exception ex) {
                MessageBox.Show("خطأ في تحميل المبيعات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int saleId = Convert.ToInt32(dgvSales.Rows[e.RowIndex].Cells["Id"].Value);

            if (dgvSales.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("هل أنت متأكد من حذف هذا الطلب؟ سيتم استعادة الكميات إلى المخزن.", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_salesRepo.DeleteSale(saleId))
                    {
                        RefreshData();
                    }
                }
            }
            else if (dgvSales.Columns[e.ColumnIndex].Name == "Edit")
            {
                using (var editForm = new Popups.AddSaleForm(saleId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        RefreshData();
                    }
                }
            }
            else if (dgvSales.Columns[e.ColumnIndex].Name == "DeleteAll")
            {
                if (MessageBox.Show("تحذير حرج: هل أنت متأكد من حذف كافة الطلبات واستعادة المخزون؟ لا يمكن التراجع عن هذه العملية!", "حذف شامل للطلبات", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_salesRepo.PurgeAllSales())
                    {
                        RefreshData();
                    }
                    else
                    {
                        MessageBox.Show("فشل في مسح بيانات المبيعات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadStatistics()
        {
            try {
                // Total Revenue
                DataTable dtRev = Helpers.DbHelper.ExecuteQuery("SELECT SUM(GrandTotal) FROM Sales");
                decimal totalRev = (dtRev.Rows.Count > 0 && dtRev.Rows[0][0] != DBNull.Value) ? Convert.ToDecimal(dtRev.Rows[0][0]) : 0;
                lblTotalRevenue.Text = totalRev.ToString("C2");

                // Total Orders
                DataTable dtOrders = Helpers.DbHelper.ExecuteQuery("SELECT COUNT(*) FROM Sales");
                int totalOrders = (dtOrders.Rows.Count > 0) ? Convert.ToInt32(dtOrders.Rows[0][0]) : 0;
                lblTotalOrders.Text = totalOrders.ToString();

                // Top Customer
                DataTable dtCust = Helpers.DbHelper.ExecuteQuery("SELECT CustomerName, SUM(GrandTotal) as Total FROM Sales GROUP BY CustomerName ORDER BY Total DESC LIMIT 1");
                string topCust = (dtCust.Rows.Count > 0) ? dtCust.Rows[0]["CustomerName"].ToString() : "N/A";
                lblTopCustomer.Text = topCust;
            } catch {
                // Silent fail for stats
            }
        }

        private void btnNewSale_Click(object sender, EventArgs e)
        {
            using (var addSaleForm = new Popups.AddSaleForm())
            {
                if (addSaleForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshData();
                }
            }
        }

        private void btnEditSale_Click(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null)
            {
                MessageBox.Show("يرجى اختيار طلب لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int saleId = Convert.ToInt32(dgvSales.CurrentRow.Cells["Id"].Value);
            using (var editForm = new Popups.AddSaleForm(saleId))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshData();
                }
            }
        }

        private void btnDeleteSale_Click(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null)
            {
                MessageBox.Show("يرجى اختيار طلب لحذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int saleId = Convert.ToInt32(dgvSales.CurrentRow.Cells["Id"].Value);
            if (MessageBox.Show("هل أنت متأكد من حذف هذا الطلب؟ سيتم استعادة الكميات إلى المخزن.", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_salesRepo.DeleteSale(saleId))
                {
                    RefreshData();
                }
            }
        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("تحذير حرج: حذف كافة الطلبات واستعادة المخزون؟ لا يمكن التراجع!", "حذف شامل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_salesRepo.PurgeAllSales())
                {
                    RefreshData();
                }
            }
        }
    }
}
