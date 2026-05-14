using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using inventory.DAL;

namespace inventory.Presentation
{
    public partial class CategoriesForm : Form
    {
        private CategoryRepository _categoryRepo = new CategoryRepository();

        public CategoriesForm()
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
        }

        private void LoadData()
        {
            dgvCategories.DataSource = _categoryRepo.GetAllCategories();
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dgvCategories.Columns.Contains("Id")) dgvCategories.Columns["Id"].Visible = false;
            ApplyUI(); // Ensure theme is re-applied after data bind
            dgvCategories.DataBindingComplete += (s, ev) => {
                if (dgvCategories.Columns.Contains("Name")) dgvCategories.Columns["Name"].HeaderText = "الاسم";
                if (dgvCategories.Columns.Contains("Description")) dgvCategories.Columns["Description"].HeaderText = "الوصف";
                
                dgvCategories.ClearSelection();
                dgvCategories.CurrentCell = null;
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("يرجى إدخال اسم القسم.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            inventory.Models.Category cat = new inventory.Models.Category
            {
                Name = categoryName,
                Description = txtDescription.Text.Trim()
            };

            if (_categoryRepo.AddCategory(cat))
            {
                MessageBox.Show("تم إضافة القسم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategoryName.Clear();
                txtDescription.Clear();
                LoadData();
            }
            else
            {
                MessageBox.Show("فشل إضافة القسم. قد يكون الاسم موجوداً مسبقاً.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            (dgvCategories.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", filter);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCategories.SelectedRows[0].Cells["Id"].Value);
                if (MessageBox.Show("هل أنت متأكد من حذف هذا القسم؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_categoryRepo.DeleteCategory(id))
                    {
                        LoadData();
                    }
                }
            }
        }
    }
}
