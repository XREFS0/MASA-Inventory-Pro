using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using inventory.DAL;
using inventory.Models;

namespace inventory.Presentation
{
    public partial class SuppliersForm : Form
    {
        private SupplierRepository _supplierRepo = new SupplierRepository();

        public SuppliersForm()
        {
            InitializeComponent();
            FindImagePath();
            LoadIcons();
            LoadData();
            ApplyUI();
        }

        private string imagePath = "";
        private void FindImagePath()
        {
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
            SetButtonIcon(btnAdd, "Add.png");
            SetButtonIcon(btnDelete, "Delete.png");
        }

        private void SetButtonIcon(Guna.UI2.WinForms.Guna2Button btn, string fileName)
        {
            string fullPath = Path.Combine(imagePath, fileName);
            if (File.Exists(fullPath))
            {
                btn.Image = Image.FromFile(fullPath);
                btn.ImageSize = new Size(20, 20);
                btn.ImageAlign = HorizontalAlignment.Left;
                btn.ImageOffset = new Point(5, 0);
                btn.TextOffset = new Point(5, 0);
            }
        }

        private void ApplyUI()
        {
            Helpers.ThemeManager.ApplyTheme(this);
            // Re-apply icons after theme
            LoadIcons();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            (dgvSuppliers.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%' OR Phone LIKE '%{0}%'", filter);
        }

        private void LoadData()
        {
            dgvSuppliers.DataSource = _supplierRepo.GetAllSuppliers();
            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dgvSuppliers.Columns.Contains("Id")) dgvSuppliers.Columns["Id"].Visible = false;
            ApplyUI(); // Ensure theme is re-applied after data bind
            dgvSuppliers.DataBindingComplete += (s, ev) => {
                if (dgvSuppliers.Columns.Contains("Name")) dgvSuppliers.Columns["Name"].HeaderText = "الاسم";
                if (dgvSuppliers.Columns.Contains("Phone")) dgvSuppliers.Columns["Phone"].HeaderText = "الهاتف";
                if (dgvSuppliers.Columns.Contains("Email")) dgvSuppliers.Columns["Email"].HeaderText = "البريد الإلكتروني";
                if (dgvSuppliers.Columns.Contains("Address")) dgvSuppliers.Columns["Address"].HeaderText = "العنوان";
                
                dgvSuppliers.ClearSelection();
                dgvSuppliers.CurrentCell = null;
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم المورد.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Supplier s = new Supplier
            {
                Name = txtSupplierName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            if (_supplierRepo.AddSupplier(s))
            {
                MessageBox.Show("تم إضافة المورد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadData();
            }
            else
            {
                MessageBox.Show("فشل إضافة المورد. يرجى التحقق من قاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtSupplierName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSuppliers.SelectedRows[0].Cells["Id"].Value);
                if (MessageBox.Show("هل أنت متأكد من حذف هذا المورد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_supplierRepo.DeleteSupplier(id))
                    {
                        LoadData();
                    }
                }
            }
        }
    }
}
