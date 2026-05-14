namespace inventory.Presentation
{
    partial class SalesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvSales = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnNewSale = new Guna.UI2.WinForms.Guna2Button();
            this.cardTotalRevenue = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblRevTitle = new System.Windows.Forms.Label();
            this.cardTotalOrders = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblOrdersTitle = new System.Windows.Forms.Label();
            this.cardTopCustomer = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTopCustomer = new System.Windows.Forms.Label();
            this.lblCustTitle = new System.Windows.Forms.Label();
            this.btnEditSale = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteSale = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteAll = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.cardTotalRevenue.SuspendLayout();
            this.cardTotalOrders.SuspendLayout();
            this.cardTopCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(204, 41);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "الطلبات الأخيرة";
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.dgvSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSales.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.dgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSales.ColumnHeadersHeight = 50;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSales.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.dgvSales.Location = new System.Drawing.Point(30, 200);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.ReadOnly = true;
            this.dgvSales.RowHeadersVisible = false;
            this.dgvSales.RowTemplate.Height = 45;
            this.dgvSales.Size = new System.Drawing.Size(980, 420);
            this.dgvSales.TabIndex = 11;
            this.dgvSales.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.dgvSales.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.dgvSales.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSales.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSales.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSales.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSales.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
            this.dgvSales.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.dgvSales.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.dgvSales.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSales.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvSales.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSales.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSales.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvSales.ThemeStyle.ReadOnly = true;
            this.dgvSales.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.dgvSales.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSales.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvSales.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSales.ThemeStyle.RowsStyle.Height = 45;
            this.dgvSales.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.dgvSales.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // btnNewSale
            // 
            this.btnNewSale.BorderRadius = 15;
            this.btnNewSale.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnNewSale.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNewSale.ForeColor = System.Drawing.Color.White;
            this.btnNewSale.Location = new System.Drawing.Point(830, 20);
            this.btnNewSale.Name = "btnNewSale";
            this.btnNewSale.Size = new System.Drawing.Size(180, 45);
            this.btnNewSale.TabIndex = 7;
            this.btnNewSale.Text = "+ طلب جديد";
            this.btnNewSale.Click += new System.EventHandler(this.btnNewSale_Click);
            // 
            // cardTotalRevenue
            // 
            this.cardTotalRevenue.BorderRadius = 20;
            this.cardTotalRevenue.Controls.Add(this.lblTotalRevenue);
            this.cardTotalRevenue.Controls.Add(this.lblRevTitle);
            this.cardTotalRevenue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.cardTotalRevenue.Location = new System.Drawing.Point(30, 80);
            this.cardTotalRevenue.Name = "cardTotalRevenue";
            this.cardTotalRevenue.Size = new System.Drawing.Size(310, 100);
            this.cardTotalRevenue.TabIndex = 4;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.lblTotalRevenue.Location = new System.Drawing.Point(20, 45);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(78, 32);
            this.lblTotalRevenue.TabIndex = 0;
            this.lblTotalRevenue.Text = "$0.00";
            // 
            // lblRevTitle
            // 
            this.lblRevTitle.AutoSize = true;
            this.lblRevTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRevTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRevTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.lblRevTitle.Location = new System.Drawing.Point(20, 20);
            this.lblRevTitle.Name = "lblRevTitle";
            this.lblRevTitle.Size = new System.Drawing.Size(105, 19);
            this.lblRevTitle.TabIndex = 1;
            this.lblRevTitle.Text = "إجمالي الإيرادات";
            // 
            // cardTotalOrders
            // 
            this.cardTotalOrders.BorderRadius = 20;
            this.cardTotalOrders.Controls.Add(this.lblTotalOrders);
            this.cardTotalOrders.Controls.Add(this.lblOrdersTitle);
            this.cardTotalOrders.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.cardTotalOrders.Location = new System.Drawing.Point(365, 80);
            this.cardTotalOrders.Name = "cardTotalOrders";
            this.cardTotalOrders.Size = new System.Drawing.Size(310, 100);
            this.cardTotalOrders.TabIndex = 5;
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTotalOrders.Location = new System.Drawing.Point(20, 45);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(29, 32);
            this.lblTotalOrders.TabIndex = 0;
            this.lblTotalOrders.Text = "0";
            // 
            // lblOrdersTitle
            // 
            this.lblOrdersTitle.AutoSize = true;
            this.lblOrdersTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.lblOrdersTitle.Location = new System.Drawing.Point(20, 20);
            this.lblOrdersTitle.Name = "lblOrdersTitle";
            this.lblOrdersTitle.Size = new System.Drawing.Size(102, 19);
            this.lblOrdersTitle.TabIndex = 1;
            this.lblOrdersTitle.Text = "إجمالي الطلبات";
            // 
            // cardTopCustomer
            // 
            this.cardTopCustomer.BorderRadius = 20;
            this.cardTopCustomer.Controls.Add(this.lblTopCustomer);
            this.cardTopCustomer.Controls.Add(this.lblCustTitle);
            this.cardTopCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.cardTopCustomer.Location = new System.Drawing.Point(700, 80);
            this.cardTopCustomer.Name = "cardTopCustomer";
            this.cardTopCustomer.Size = new System.Drawing.Size(310, 100);
            this.cardTopCustomer.TabIndex = 6;
            // 
            // lblTopCustomer
            // 
            this.lblTopCustomer.AutoSize = true;
            this.lblTopCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblTopCustomer.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTopCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.lblTopCustomer.Location = new System.Drawing.Point(20, 45);
            this.lblTopCustomer.Name = "lblTopCustomer";
            this.lblTopCustomer.Size = new System.Drawing.Size(48, 25);
            this.lblTopCustomer.TabIndex = 0;
            this.lblTopCustomer.Text = "N/A";
            // 
            // lblCustTitle
            // 
            this.lblCustTitle.AutoSize = true;
            this.lblCustTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCustTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCustTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.lblCustTitle.Location = new System.Drawing.Point(20, 20);
            this.lblCustTitle.Name = "lblCustTitle";
            this.lblCustTitle.Size = new System.Drawing.Size(77, 19);
            this.lblCustTitle.TabIndex = 1;
            this.lblCustTitle.Text = "أفضل عميل";
            // 
            // btnEditSale
            // 
            this.btnEditSale.BorderRadius = 15;
            this.btnEditSale.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.btnEditSale.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditSale.ForeColor = System.Drawing.Color.White;
            this.btnEditSale.Location = new System.Drawing.Point(650, 20);
            this.btnEditSale.Name = "btnEditSale";
            this.btnEditSale.Size = new System.Drawing.Size(85, 45);
            this.btnEditSale.TabIndex = 10;
            this.btnEditSale.Text = "تعديل";
            this.btnEditSale.Click += new System.EventHandler(this.btnEditSale_Click);
            // 
            // btnDeleteSale
            // 
            this.btnDeleteSale.BorderRadius = 15;
            this.btnDeleteSale.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnDeleteSale.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteSale.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSale.Location = new System.Drawing.Point(740, 20);
            this.btnDeleteSale.Name = "btnDeleteSale";
            this.btnDeleteSale.Size = new System.Drawing.Size(85, 45);
            this.btnDeleteSale.TabIndex = 8;
            this.btnDeleteSale.Text = "حذف";
            this.btnDeleteSale.Click += new System.EventHandler(this.btnDeleteSale_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.BorderRadius = 15;
            this.btnDeleteAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnDeleteAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAll.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAll.Location = new System.Drawing.Point(490, 20);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(150, 45);
            this.btnDeleteAll.TabIndex = 9;
            this.btnDeleteAll.Text = "حذف الكل";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // SalesForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1040, 655);
            this.Controls.Add(this.cardTopCustomer);
            this.Controls.Add(this.cardTotalOrders);
            this.Controls.Add(this.cardTotalRevenue);
            this.Controls.Add(this.btnNewSale);
            this.Controls.Add(this.btnDeleteSale);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnEditSale);
            this.Controls.Add(this.dgvSales);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALES";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.cardTotalRevenue.ResumeLayout(false);
            this.cardTotalRevenue.PerformLayout();
            this.cardTotalOrders.ResumeLayout(false);
            this.cardTotalOrders.PerformLayout();
            this.cardTopCustomer.ResumeLayout(false);
            this.cardTopCustomer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSales;
        private Guna.UI2.WinForms.Guna2Button btnNewSale;
        private Guna.UI2.WinForms.Guna2Button btnEditSale;
        private Guna.UI2.WinForms.Guna2Button btnDeleteSale;
        private Guna.UI2.WinForms.Guna2Button btnDeleteAll;
        private Guna.UI2.WinForms.Guna2Panel cardTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblRevTitle;
        private Guna.UI2.WinForms.Guna2Panel cardTotalOrders;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblOrdersTitle;
        private Guna.UI2.WinForms.Guna2Panel cardTopCustomer;
        private System.Windows.Forms.Label lblTopCustomer;
        private System.Windows.Forms.Label lblCustTitle;
    }
}
