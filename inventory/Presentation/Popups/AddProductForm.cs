using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using inventory.Models;
using inventory.BLL;
using inventory.DAL;
using inventory.Helpers;

namespace inventory.Presentation.Popups
{
    public partial class AddProductForm : Form
    {
        private ProductService _productService = new ProductService();
        private CategoryRepository _categoryRepo = new CategoryRepository();
        private SupplierRepository _supplierRepo = new SupplierRepository();

        public AddProductForm()
        {
            InitializeComponent();
            FindImagePath();
            LoadIcons();
            LoadCombos();
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
            string addIcon = Path.Combine(imagePath, "Add.png");
            if (File.Exists(addIcon))
            {
                btnSave.Image = Image.FromFile(addIcon);
                btnSave.ImageSize = new Size(20, 20);
                btnSave.ImageAlign = HorizontalAlignment.Left;
                btnSave.ImageOffset = new Point(10, 0);
                btnSave.TextOffset = new Point(15, 0);
            }
        }

        private void ApplyUI()
        {
            ThemeManager.ApplyTheme(this);
        }

        private void LoadCombos()
        {
            cmbCategory.DataSource = _categoryRepo.GetAllCategories();
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";

            cmbSupplier.DataSource = _supplierRepo.GetAllSuppliers();
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "Id";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                if (string.IsNullOrWhiteSpace(txtName.Text)) {
                    MessageBox.Show("يرجى إدخال اسم المنتج.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal purchasePrice, salePrice;
                int stock, minStock;

                if (!decimal.TryParse(txtPurchasePrice.Text, out purchasePrice) || 
                    !decimal.TryParse(txtSalePrice.Text, out salePrice) ||
                    !int.TryParse(txtStock.Text, out stock) ||
                    !int.TryParse(txtMinStock.Text, out minStock))
                {
                    MessageBox.Show("يرجى إدخال قيم عددية صحيحة للأسعار والكمية.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Product p = new Product {
                    Name = txtName.Text.Trim(),
                    Barcode = txtBarcode.Text.Trim(),
                    CategoryId = Convert.ToInt32(cmbCategory.SelectedValue),
                    SupplierId = Convert.ToInt32(cmbSupplier.SelectedValue),
                    PurchasePrice = purchasePrice,
                    SalePrice = salePrice,
                    StockQuantity = stock,
                    MinStockAlert = minStock,
                    Unit = txtUnit.Text.Trim(),
                    CreatedAt = DateTime.Now
                };

                if (_productService.SaveProduct(p))
                {
                    MessageBox.Show("تم حفظ المنتج بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show("خطأ في حفظ المنتج: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
