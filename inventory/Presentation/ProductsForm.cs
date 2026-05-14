using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using inventory.BLL;

namespace inventory.Presentation
{
    public partial class ProductsForm : Form
    {
        private ProductService _productService = new ProductService();

        public ProductsForm()
        {
            InitializeComponent();
            FindImagePath();
            LoadIcons();
            SetTags();
            this.Shown += (s, e) => LoadData();
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
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
            SetButtonIcon(btnEdit, "Edit.png");
            SetButtonIcon(btnDelete, "Delete.png");
            SetButtonIcon(btnExport, "report.png");
            
            txtSearch.IconLeft = Image.FromFile(Path.Combine(imagePath, "search.png"));
            txtSearch.IconLeftOffset = new Point(10, 0);
            txtSearch.IconLeftSize = new Size(20, 20);
        }

        private void SetButtonIcon(Guna.UI2.WinForms.Guna2Button btn, string fileName)
        {
            string fullPath = Path.Combine(imagePath, fileName);
            if (File.Exists(fullPath))
            {
                btn.Image = Image.FromFile(fullPath);
                btn.ImageSize = new Size(20, 20);
                btn.ImageAlign = HorizontalAlignment.Left;
                btn.ImageOffset = new Point(10, 0);
                btn.TextOffset = new Point(15, 0);
            }
        }

        private void SetTags()
        {
            this.lblTitle.Text = "المنتجات";
            txtSearch.Tag = "Search";
            btnAdd.Tag = "Accent";
            btnEdit.Tag = "Accent";
        }

        private void ApplyUI()
        {
            Helpers.ThemeManager.ApplyTheme(this);
            Helpers.LanguageManager.ApplyLanguage(this);
        }

        private void LoadData()
        {
            try {
                DataTable dt = _productService.GetAllProducts();
                dgvProducts.DataSource = null;
                dgvProducts.AutoGenerateColumns = true;
                dgvProducts.DataSource = dt;

                // Formatting after binding
                if (dgvProducts.Columns.Contains("Id")) dgvProducts.Columns["Id"].Visible = false;
                if (dgvProducts.Columns.Contains("CategoryId")) dgvProducts.Columns["CategoryId"].Visible = false;
                if (dgvProducts.Columns.Contains("SupplierId")) dgvProducts.Columns["SupplierId"].Visible = false;
                if (dgvProducts.Columns.Contains("ProductImage")) dgvProducts.Columns["ProductImage"].Visible = false;

                if (dgvProducts.Columns.Contains("Barcode")) dgvProducts.Columns["Barcode"].HeaderText = "باركود";
                if (dgvProducts.Columns.Contains("Name")) dgvProducts.Columns["Name"].HeaderText = "الاسم";
                if (dgvProducts.Columns.Contains("Description")) dgvProducts.Columns["Description"].HeaderText = "الوصف";
                if (dgvProducts.Columns.Contains("PurchasePrice")) dgvProducts.Columns["PurchasePrice"].HeaderText = "سعر الشراء";
                if (dgvProducts.Columns.Contains("SalePrice")) dgvProducts.Columns["SalePrice"].HeaderText = "سعر البيع";
                if (dgvProducts.Columns.Contains("StockQuantity")) dgvProducts.Columns["StockQuantity"].HeaderText = "الكمية";
                if (dgvProducts.Columns.Contains("MinStockAlert")) dgvProducts.Columns["MinStockAlert"].HeaderText = "الحد الأدنى";
                if (dgvProducts.Columns.Contains("Unit")) dgvProducts.Columns["Unit"].HeaderText = "الوحدة";
                if (dgvProducts.Columns.Contains("CategoryName")) dgvProducts.Columns["CategoryName"].HeaderText = "القسم";
                if (dgvProducts.Columns.Contains("SupplierName")) dgvProducts.Columns["SupplierName"].HeaderText = "المورد";
                if (dgvProducts.Columns.Contains("CreatedAt")) dgvProducts.Columns["CreatedAt"].HeaderText = "تاريخ الإضافة";

                if (dgvProducts.Columns.Contains("Edit")) dgvProducts.Columns.Remove("Edit");
                dgvProducts.Columns.Add(new DataGridViewImageColumn { Name = "Edit", HeaderText = "", Width = 50, ImageLayout = DataGridViewImageCellLayout.Zoom });
                
                if (dgvProducts.Columns.Contains("Delete")) dgvProducts.Columns.Remove("Delete");
                dgvProducts.Columns.Add(new DataGridViewImageColumn { Name = "Delete", HeaderText = "", Width = 50, ImageLayout = DataGridViewImageCellLayout.Zoom });

                if (dgvProducts.Columns.Contains("DeleteAll")) dgvProducts.Columns.Remove("DeleteAll");
                dgvProducts.Columns.Add(new DataGridViewImageColumn { Name = "DeleteAll", HeaderText = "", Width = 50, ImageLayout = DataGridViewImageCellLayout.Zoom });

                ApplyUI();
                ApplyStockFormatting();
                dgvProducts.ClearSelection();
            } catch (Exception) {
                // System.Windows.Forms.MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void ApplyStockFormatting()
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.Cells["StockQuantity"].Value == null || row.Cells["StockQuantity"].Value == DBNull.Value) continue;

                int stock = Convert.ToInt32(row.Cells["StockQuantity"].Value);
                int minStock = Convert.ToInt32(row.Cells["MinStockAlert"].Value);

                if (stock <= minStock)
                {
                    // Premium Low Stock Look: Subtle Red Background for the whole row
                    row.DefaultCellStyle.BackColor = Color.FromArgb(45, 20, 20); // Dark muted red
                    row.Cells["StockQuantity"].Style.ForeColor = Color.FromArgb(255, 82, 82); // Bright red text for quantity
                    row.Cells["StockQuantity"].Style.Font = new Font(dgvProducts.Font, FontStyle.Bold);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Empty; // Reset if filtered
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new Popups.AddProductForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Id"].Value);
                using (var editForm = new inventory.Presentation.Popups.EditProductForm(productId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("يرجى اختيار منتج لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Id"].Value);
                if (MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا المنتج؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (_productService.DeleteProduct(id))
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("يرجى اختيار منتج لحذفه.");
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string colName = dgvProducts.Columns[e.ColumnIndex].Name;
            int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["Id"].Value);

            if (colName == "Edit")
            {
                using (var editForm = new Popups.EditProductForm(productId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK) LoadData();
                }
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل تريد حذف هذا المنتج؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (_productService.DeleteProduct(productId)) LoadData();
                }
            }
            else if (colName == "DeleteAll")
            {
                if (MessageBox.Show("تحذير حرج: هل أنت متأكد من حذف كافة المنتجات؟ لا يمكن التراجع عن هذه العملية!", "حذف شامل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_productService.PurgeAll()) LoadData();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            if (dgvProducts.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("Name LIKE '%{0}%' OR Barcode LIKE '%{0}%'", filter);
            }
            ApplyStockFormatting();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv";
                    sfd.FileName = $"Products_Export_{DateTime.Now:yyyyMMdd}.csv";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                        {
                            // Write Headers
                            for (int i = 0; i < dgvProducts.Columns.Count; i++)
                            {
                                if (!dgvProducts.Columns[i].Visible) continue;
                                sw.Write(dgvProducts.Columns[i].HeaderText);
                                if (i < dgvProducts.Columns.Count - 1) sw.Write(",");
                            }
                            sw.WriteLine();

                            // Write Data
                            foreach (DataGridViewRow row in dgvProducts.Rows)
                            {
                                if (row.IsNewRow) continue;
                                for (int i = 0; i < dgvProducts.Columns.Count; i++)
                                {
                                    if (!dgvProducts.Columns[i].Visible) continue;
                                    string val = row.Cells[i].Value?.ToString().Replace(",", " ") ?? "";
                                    sw.Write(val);
                                    if (i < dgvProducts.Columns.Count - 1) sw.Write(",");
                                }
                                sw.WriteLine();
                            }
                        }
                        MessageBox.Show("تم تصدير المنتجات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل التصدير: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("تحذير حرج: هل أنت متأكد من حذف كافة المنتجات؟ لا يمكن التراجع عن هذه العملية!", "حذف شامل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_productService.PurgeAll()) LoadData();
            }
        }
    }
}
