using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using inventory.Helpers;

namespace inventory.Presentation
{
    public partial class MainForm : Form
    {
        private string imagePath = "";

        public MainForm()
        {
            InitializeComponent();
            Helpers.DataSeeder.SeedAllData();
            FindImagePath();
            LoadIcons();
            SetTags();
            RefreshGlobalUI();
            this.Text = "ماسا لإدارة المخزون - النسخة الاحترافية v1.0";
            notifyIcon1.Icon = this.Icon;
            OpenChildForm(new DashboardForm());
        }

        private void SetTags()
        {
            btnDashboard.Tag = "Dashboard";
            btnProducts.Tag = "Products";
            btnOrders.Tag = "Orders";
            btnCategories.Tag = "Categories";
            btnSuppliers.Tag = "Suppliers";
            btnHelp.Tag = "Help";
        }

        public void RefreshGlobalUI()
        {
            Helpers.ThemeManager.ApplyTheme(this);
            Helpers.LanguageManager.ApplyLanguage(this);
            
            // Re-apply header title based on active form
            if (activeForm != null)
                lblHeaderTitle.Text = Helpers.LanguageManager.GetString(activeForm.Tag?.ToString() ?? activeForm.Text);
        }

        private void FindImagePath()
        {
            // Search for Assets folder in current and parent directories
            string path = Application.StartupPath;
            while (!Directory.Exists(Path.Combine(path, "Assets")) && path.Length > 3)
            {
                path = Path.GetDirectoryName(path);
            }
            imagePath = Path.Combine(path, "Assets", "Images");
        }

        private void LoadIcons()
        {
            if (!Directory.Exists(imagePath)) return;

            SetIcon(btnDashboard, "Dashboard.png");
            SetIcon(btnProducts, "Products.png");
            SetIcon(btnOrders, "Orders.png");
            this.notifyIcon1.Text = "MASA Inventory Pro";
            this.notifyIcon1.Visible = true;
            SetIcon(btnCategories, "categories.png");
            SetIcon(btnSuppliers, "supplier.png");
            SetIcon(btnHelp, "help.png");
            
        }

        private void SetIcon(Guna.UI2.WinForms.Guna2Button btn, string fileName)
        {
            string fullPath = Path.Combine(imagePath, fileName);
            if (File.Exists(fullPath))
            {
                btn.Image = Image.FromFile(fullPath);
                btn.ImageSize = new Size(24, 24);
                btn.ImageAlign = HorizontalAlignment.Left;
                btn.ImageOffset = new Point(15, 0);
                btn.TextOffset = new Point(30, 0);
            }
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;
            
            childForm.Show();
            childForm.BringToFront();
            lblHeaderTitle.Text = childForm.Text;
        }

        private void MoveSelectionIndicator(Control btn)
        {
            if (btn == null) return;
            pnlSelectionIndicator.Top = btn.Top;
            pnlSelectionIndicator.Height = btn.Height;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MoveSelectionIndicator((Control)sender);
            lblHeaderTitle.Text = "لوحة التحكم";
            OpenChildForm(new DashboardForm());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            MoveSelectionIndicator((Control)sender);
            lblHeaderTitle.Text = "المنتجات";
            OpenChildForm(new ProductsForm());
        }

        public void btnOrders_Click(object sender, EventArgs e)
        {
            MoveSelectionIndicator((Control)sender);
            lblHeaderTitle.Text = "الطلبات";
            OpenChildForm(new SalesForm());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            MoveSelectionIndicator((Control)sender);
            lblHeaderTitle.Text = "الأقسام";
            OpenChildForm(new inventory.Presentation.CategoriesForm());
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            MoveSelectionIndicator((Control)sender);
            lblHeaderTitle.Text = "الموردين";
            OpenChildForm(new inventory.Presentation.SuppliersForm());
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MoveSelectionIndicator((Control)sender);
            lblHeaderTitle.Text = "المساعدة والدعم";
            OpenChildForm(new HelpForm());
        }

        public void ShowNotification(string title, string message, ToolTipIcon icon = ToolTipIcon.Info)
        {
            notifyIcon1.ShowBalloonTip(3000, title, message, icon);
        }
    }
}
