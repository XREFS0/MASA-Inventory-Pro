using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using inventory.Models;
using inventory.DAL;
using inventory.Helpers;

namespace inventory.Presentation.Popups
{
    public partial class AddSaleForm : Form
    {
        private ProductRepository _productRepo = new ProductRepository();
        private SalesRepository _salesRepo = new SalesRepository();
        private DataTable _dtProducts;
        private List<SaleItem> _cartItems = new List<SaleItem>();
        private bool _isEditMode = false;
        private int _existingSaleId;

        public AddSaleForm()
        {
            InitializeComponent();
            FindImagePath();
            LoadIcons();
            SetTags();
            LoadProducts();
            SetupGrid();
            ApplyUI();
        }

        public AddSaleForm(int saleId) : this()
        {
            _isEditMode = true;
            _existingSaleId = saleId;
            LoadExistingSale();
        }

        private void SetupGrid()
        {
            // Enable editing for Qty column
            dgvCart.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvCart.Columns)
            {
                if (col.Name != "colQty") col.ReadOnly = true;
            }
            dgvCart.CellValueChanged += dgvCart_CellValueChanged;
        }

        private void LoadExistingSale()
        {
            var sale = _salesRepo.GetSaleById(_existingSaleId);
            if (sale != null)
            {
                txtCustomerName.Text = sale.CustomerName;
                txtDiscount.Text = sale.Discount.ToString();
                
                var items = _salesRepo.GetSaleItemsBySaleId(_existingSaleId);
                _cartItems = items;
                
                // We need to wait for _dtProducts to be loaded, but it is loaded in constructor
                // RefreshCartGrid will handle it.
                this.Shown += (s, e) => RefreshCartGrid();
                
                lblTitle.Text = "Edit Order #" + _existingSaleId;
                btnConfirm.Text = "Update Order";
            }
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCart.Columns[e.ColumnIndex].Name == "colQty")
            {
                var row = dgvCart.Rows[e.RowIndex];
                var item = row.Tag as SaleItem;
                if (item != null)
                {
                    if (int.TryParse(row.Cells["colQty"].Value?.ToString(), out int newQty) && newQty > 0)
                    {
                        item.Quantity = newQty;
                        item.TotalPrice = item.Quantity * item.UnitPrice;
                        
                        // Update total cell and labels without full refresh to keep focus
                        row.Cells["colTotal"].Value = item.TotalPrice.ToString("N2");
                        CalculateTotals();
                    }
                    else
                    {
                        // Revert if invalid
                        row.Cells["colQty"].Value = item.Quantity;
                    }
                }
            }
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
            string confirmIcon = Path.Combine(imagePath, "Orders.png");
            if (File.Exists(confirmIcon))
            {
                btnConfirm.Image = Image.FromFile(confirmIcon);
                btnConfirm.ImageSize = new Size(20, 20);
                btnConfirm.ImageAlign = HorizontalAlignment.Left;
                btnConfirm.ImageOffset = new Point(10, 0);
                btnConfirm.TextOffset = new Point(15, 0);
            }
            
            txtSearch.IconLeft = Image.FromFile(Path.Combine(imagePath, "search.png"));
            txtSearch.IconLeftOffset = new Point(10, 0);
            txtSearch.IconLeftSize = new Size(20, 20);
        }

        private void SetTags()
        {
            lblTitle.Tag = "SelectProducts";
            btnConfirm.Tag = "ConfirmOrder";
            lblSubtotalTitle.Tag = "Subtotal";
            lblGrandTotalTitle.Tag = "GrandTotal";
            lblDiscountTitle.Tag = "Discount";
            txtCustomerName.PlaceholderText = LanguageManager.GetString("CustomerName");
            txtSearch.PlaceholderText = LanguageManager.GetString("Search");
        }

        private void ApplyUI()
        {
            ThemeManager.ApplyTheme(this);
            LanguageManager.ApplyLanguage(this);
        }

        private void LoadProducts()
        {
            try {
                _dtProducts = _productRepo.GetAllProducts();
                dgvProducts.DataSource = _dtProducts;
                
                // Hide unnecessary columns for selection
                string[] visibleCols = { "Barcode", "Name", "SalePrice", "StockQuantity" };
                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    if (!visibleCols.Contains(col.Name))
                        col.Visible = false;
                }
                
                dgvProducts.Columns["SalePrice"].DefaultCellStyle.Format = "N2";
                dgvProducts.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            } catch (Exception ex) {
                MessageBox.Show("خطأ في تحميل المنتجات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtProducts == null) return;
            string filter = txtSearch.Text.Trim().Replace("'", "''");
            _dtProducts.DefaultView.RowFilter = string.Format("Name LIKE '%{0}%' OR Barcode LIKE '%{0}%'", filter);
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["Id"].Value);
            string name = dgvProducts.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            decimal price = Convert.ToDecimal(dgvProducts.Rows[e.RowIndex].Cells["SalePrice"].Value);
            int stock = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["StockQuantity"].Value);

            if (stock <= 0)
            {
                MessageBox.Show("عذراً، المنتج غير متوفر في المخزن!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddToCart(productId, name, price);
        }

        private void AddToCart(int productId, string name, decimal price)
        {
            var existingItem = _cartItems.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
                existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice;
            }
            else
            {
                _cartItems.Add(new SaleItem {
                    ProductId = productId,
                    Quantity = 1,
                    UnitPrice = price,
                    TotalPrice = price
                });
            }
            RefreshCartGrid();
        }

        private void RefreshCartGrid()
        {
            dgvCart.Rows.Clear();
            foreach (var item in _cartItems)
            {
                // Find product name again (or store it in a view model)
                string name = _dtProducts.AsEnumerable().FirstOrDefault(r => r.Field<long>("Id") == item.ProductId)?.Field<string>("Name") ?? "Unknown";
                int rowIndex = dgvCart.Rows.Add(name, item.Quantity, item.UnitPrice.ToString("N2"), item.TotalPrice.ToString("N2"), "X");
                dgvCart.Rows[rowIndex].Tag = item; // Store item reference for editing
            }
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            decimal subtotal = _cartItems.Sum(i => i.TotalPrice);
            decimal discount = 0;
            if (!decimal.TryParse(txtDiscount.Text, out discount)) discount = 0;
            
            decimal grandTotal = subtotal - discount;
            if (grandTotal < 0) grandTotal = 0;

            lblSubtotalValue.Text = subtotal.ToString("N2") + " EGP";
            lblGrandTotalValue.Text = grandTotal.ToString("N2") + " EGP";
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotals();
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCart.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                _cartItems.RemoveAt(e.RowIndex);
                RefreshCartGrid();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("السلة فارغة! يرجى إضافة منتجات أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                decimal subtotal = _cartItems.Sum(i => i.TotalPrice);
                decimal discount = 0;
                decimal.TryParse(txtDiscount.Text, out discount);
                
                var sale = new Sale {
                    SaleDate = DateTime.Now,
                    TotalAmount = subtotal,
                    Discount = discount,
                    GrandTotal = subtotal - discount,
                    CustomerName = string.IsNullOrWhiteSpace(txtCustomerName.Text) ? "Walk-in Customer" : txtCustomerName.Text,
                    UserId = 1 // Hardcoded admin for now, should get from Session
                };

                if (_isEditMode)
                {
                    sale.Id = _existingSaleId;
                    if (_salesRepo.UpdateSale(sale, _cartItems))
                    {
                        MessageBox.Show("تم تحديث الطلب بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    if (_salesRepo.CreateSale(sale, _cartItems))
                    {
                        if (MessageBox.Show("تم تأكيد الطلب بنجاح! هل تريد عرض أو طباعة الفاتورة؟", "طباعة الفاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            GenerateInvoice(sale, _cartItems);
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("خطأ أثناء معالجة الطلب: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateInvoice(Sale sale, List<SaleItem> items)
        {
            try
            {
                string invoicePath = Path.Combine(Application.StartupPath, "Invoices");
                if (!Directory.Exists(invoicePath)) Directory.CreateDirectory(invoicePath);

                string fileName = $"Invoice_{DateTime.Now:yyyyMMdd_HHmmss}.html";
                string fullPath = Path.Combine(invoicePath, fileName);

                string html = $@"
                <html>
                <head>
                    <style>
                        body {{ font-family: 'Segoe UI', sans-serif; color: #333; margin: 40px; background-color: #f9f9f9; }}
                        .invoice-card {{ background: white; padding: 40px; border-radius: 15px; box-shadow: 0 0 20px rgba(0,0,0,0.1); max-width: 800px; margin: auto; }}
                        .header {{ text-align: center; border-bottom: 3px solid #8C52FF; padding-bottom: 20px; margin-bottom: 30px; }}
                        .header h1 {{ color: #8C52FF; margin: 0; font-size: 2.5em; }}
                        .info {{ display: flex; justify-content: space-between; margin: 20px 0; line-height: 1.6; }}
                        table {{ width: 100%; border-collapse: collapse; margin: 30px 0; }}
                        th {{ background-color: #8C52FF; color: white; padding: 12px; text-align: left; }}
                        td {{ padding: 12px; border-bottom: 1px solid #eee; }}
                        .totals {{ text-align: right; font-size: 1.2em; font-weight: bold; margin-top: 30px; border-top: 2px solid #eee; padding-top: 20px; }}
                        .footer {{ text-align: center; margin-top: 50px; font-size: 0.9em; color: #777; border-top: 1px solid #eee; padding-top: 20px; }}
                        @media print {{
                            body {{ background: white; margin: 0; }}
                            .invoice-card {{ box-shadow: none; border: none; }}
                            button {{ display: none; }}
                        }}
                    </style>
                </head>
                <body>
                    <div class='invoice-card'>
                        <div class='header'>
                            <h1>MASA Inventory Pro</h1>
                            <p style='font-size: 1.1em; color: #666;'>Premium Inventory Management System</p>
                        </div>
                        <div class='info'>
                            <div>
                                <strong style='color: #8C52FF;'>CUSTOMER INFO:</strong><br>
                                {sale.CustomerName}<br>
                                <strong>Date:</strong> {sale.SaleDate:yyyy-MM-dd HH:mm}
                            </div>
                            <div style='text-align: right;'>
                                <strong style='color: #8C52FF;'>INVOICE DETAILS:</strong><br>
                                <strong>Invoice #:</strong> INV-{DateTime.Now:yyyyMMdd}-{DateTime.Now.Ticks % 10000}<br>
                                <strong>Status:</strong> PAID
                            </div>
                        </div>
                    <table>
                        <thead>
                            <tr>
                                <th>Product</th>
                                <th>Qty</th>
                                <th>Price</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>";

                foreach (var item in items)
                {
                    string name = _dtProducts.AsEnumerable().FirstOrDefault(r => r.Field<long>("Id") == item.ProductId)?.Field<string>("Name") ?? "Unknown";
                    html += $@"
                            <tr>
                                <td>{name}</td>
                                <td>{item.Quantity}</td>
                                <td>{item.UnitPrice:N2} EGP</td>
                                <td>{item.TotalPrice:N2} EGP</td>
                            </tr>";
                }

                html += $@"
                        </tbody>
                    </table>
                    <div class='totals'>
                        <p>Subtotal: {sale.TotalAmount:N2} EGP</p>
                        <p>Discount: {sale.Discount:N2} EGP</p>
                        <p style='color: #8C52FF; font-size: 1.4em;'>Grand Total: {sale.GrandTotal:N2} EGP</p>
                    </div>
                    <div class='footer'>
                        <p>Thank you for your business!</p>
                        <p>Generated by MASA Inventory Pro</p>
                    </div>
                    </div>
                    <div style='text-align: center; margin-top: 20px;'>
                        <button onclick='window.print()' style='background: #8C52FF; color: white; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; font-size: 1em;'>Print / Save as PDF</button>
                    </div>
                </body>
                </html>";

                File.WriteAllText(fullPath, html);
                Process.Start(fullPath); // Open automatically
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل في إنشاء الفاتورة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
