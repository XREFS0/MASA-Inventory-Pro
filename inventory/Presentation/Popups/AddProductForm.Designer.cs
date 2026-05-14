namespace inventory.Presentation.Popups
{
    partial class AddProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBarcode = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPurchasePrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSalePrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtStock = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMinStock = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUnit = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbSupplier = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Text = "تفاصيل المنتج";

            // txtName
            this.txtName.BorderRadius = 8;
            this.txtName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(20, 80);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "اسم المنتج";
            this.txtName.Size = new System.Drawing.Size(440, 40);

            // txtBarcode
            this.txtBarcode.BorderRadius = 8;
            this.txtBarcode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtBarcode.ForeColor = System.Drawing.Color.White;
            this.txtBarcode.Location = new System.Drawing.Point(20, 130);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.PlaceholderText = "الباركود / SKU";
            this.txtBarcode.Size = new System.Drawing.Size(440, 40);

            // cmbCategory
            this.cmbCategory.BorderRadius = 8;
            this.cmbCategory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbCategory.ForeColor = System.Drawing.Color.White;
            this.cmbCategory.ItemHeight = 30;
            this.cmbCategory.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbCategory.ItemsAppearance.ForeColor = System.Drawing.Color.White;
            this.cmbCategory.Location = new System.Drawing.Point(20, 180);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(210, 40);

            // cmbSupplier
            this.cmbSupplier.BorderRadius = 8;
            this.cmbSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbSupplier.ForeColor = System.Drawing.Color.White;
            this.cmbSupplier.ItemHeight = 30;
            this.cmbSupplier.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbSupplier.ItemsAppearance.ForeColor = System.Drawing.Color.White;
            this.cmbSupplier.Location = new System.Drawing.Point(250, 180);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(210, 40);

            // txtPurchasePrice
            this.txtPurchasePrice.BorderRadius = 8;
            this.txtPurchasePrice.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtPurchasePrice.ForeColor = System.Drawing.Color.White;
            this.txtPurchasePrice.Location = new System.Drawing.Point(20, 235);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.PlaceholderText = "سعر الشراء";
            this.txtPurchasePrice.Size = new System.Drawing.Size(130, 40);

            // txtSalePrice
            this.txtSalePrice.BorderRadius = 8;
            this.txtSalePrice.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtSalePrice.ForeColor = System.Drawing.Color.White;
            this.txtSalePrice.Location = new System.Drawing.Point(160, 235);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.PlaceholderText = "سعر البيع";
            this.txtSalePrice.Size = new System.Drawing.Size(130, 40);

            // txtStock
            this.txtStock.BorderRadius = 8;
            this.txtStock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtStock.ForeColor = System.Drawing.Color.White;
            this.txtStock.Location = new System.Drawing.Point(300, 235);
            this.txtStock.Name = "txtStock";
            this.txtStock.PlaceholderText = "الكمية الحالية";
            this.txtStock.Size = new System.Drawing.Size(160, 40);

            // txtMinStock
            this.txtMinStock.BorderRadius = 8;
            this.txtMinStock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtMinStock.ForeColor = System.Drawing.Color.White;
            this.txtMinStock.Location = new System.Drawing.Point(20, 285);
            this.txtMinStock.Name = "txtMinStock";
            this.txtMinStock.PlaceholderText = "تنبيه نقص المخزون";
            this.txtMinStock.Size = new System.Drawing.Size(130, 40);
            this.txtMinStock.Text = "5";

            // txtUnit
            this.txtUnit.BorderRadius = 8;
            this.txtUnit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtUnit.ForeColor = System.Drawing.Color.White;
            this.txtUnit.Location = new System.Drawing.Point(160, 285);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.PlaceholderText = "الوحدة (قطعة، علبة...)";
            this.txtUnit.Size = new System.Drawing.Size(130, 40);
            this.txtUnit.Text = "pcs";

            // btnSave
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(440, 45);
            this.btnSave.Text = "حفظ المنتج";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // AddProductForm
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(480, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.txtPurchasePrice);
            this.Controls.Add(this.txtSalePrice);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtMinStock);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إضافة منتج جديد";
        }

        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2TextBox txtBarcode;
        private Guna.UI2.WinForms.Guna2TextBox txtPurchasePrice;
        private Guna.UI2.WinForms.Guna2TextBox txtSalePrice;
        private Guna.UI2.WinForms.Guna2TextBox txtStock;
        private Guna.UI2.WinForms.Guna2TextBox txtMinStock;
        private Guna.UI2.WinForms.Guna2TextBox txtUnit;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategory;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSupplier;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label label1;
    }
}
