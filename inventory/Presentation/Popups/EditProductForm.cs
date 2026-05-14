using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using inventory.Models;
using inventory.BLL;
using inventory.DAL;
using inventory.Helpers;

namespace inventory.Presentation.Popups
{
    public partial class EditProductForm : Form
    {
        private ProductService _productService = new ProductService();
        private CategoryRepository _categoryRepo = new CategoryRepository();
        private SupplierRepository _supplierRepo = new SupplierRepository();
        private int _productId;
        private Product _currentProduct;
        public EditProductForm(int productId)
        {
            InitializeComponent();
            _productId = productId;
            FindImagePath();
            LoadIcons();
            LoadCombos();
            LoadProductData();
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
            string updateIcon = Path.Combine(imagePath, "Edit.png");
            if (File.Exists(updateIcon))
            {
                btnUpdate.Image = Image.FromFile(updateIcon);
                btnUpdate.ImageSize = new Size(20, 20);
                btnUpdate.ImageAlign = HorizontalAlignment.Left;
                btnUpdate.ImageOffset = new Point(10, 0);
                btnUpdate.TextOffset = new Point(15, 0);
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

        private void LoadProductData()
        {
            try
            {
                _currentProduct = _productService.GetProductById(_productId);
                if (_currentProduct != null)
                {
                    txtName.Text = _currentProduct.Name;
                    txtBarcode.Text = _currentProduct.Barcode;
                    cmbCategory.SelectedValue = _currentProduct.CategoryId;
                    cmbSupplier.SelectedValue = _currentProduct.SupplierId;
                    txtPurchasePrice.Text = _currentProduct.PurchasePrice.ToString();
                    txtSalePrice.Text = _currentProduct.SalePrice.ToString();
                    txtStock.Text = _currentProduct.StockQuantity.ToString();
                    txtMinStock.Text = _currentProduct.MinStockAlert.ToString();
                    txtUnit.Text = _currentProduct.Unit;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل بيانات المنتج: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
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

                _currentProduct.Name = txtName.Text.Trim();
                _currentProduct.Barcode = txtBarcode.Text.Trim();
                _currentProduct.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                _currentProduct.SupplierId = Convert.ToInt32(cmbSupplier.SelectedValue);
                _currentProduct.PurchasePrice = purchasePrice;
                _currentProduct.SalePrice = salePrice;
                _currentProduct.StockQuantity = stock;
                _currentProduct.MinStockAlert = minStock;
                _currentProduct.Unit = txtUnit.Text.Trim();

                if (_productService.UpdateProduct(_currentProduct))
                {
                    MessageBox.Show("تم تحديث بيانات المنتج بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء تحديث المنتج: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
