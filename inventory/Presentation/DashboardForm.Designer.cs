namespace inventory.Presentation
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.cardTotalProducts = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pbIcon1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lblVal1 = new System.Windows.Forms.Label();
            this.cardLowStock = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pbIcon2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.lblVal2 = new System.Windows.Forms.Label();
            this.cardTotalSales = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pbIcon3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTitle3 = new System.Windows.Forms.Label();
            this.lblVal3 = new System.Windows.Forms.Label();
            this.cardOrders = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pbIcon4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTitle4 = new System.Windows.Forms.Label();
            this.lblVal4 = new System.Windows.Forms.Label();
            this.dgvRecentActivity = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelChart1 = new Guna.UI2.WinForms.Guna2Panel();
            this.panelChart2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTableTitle = new System.Windows.Forms.Label();
            this.cardTotalProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon1)).BeginInit();
            this.cardLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon2)).BeginInit();
            this.cardTotalSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon3)).BeginInit();
            this.cardOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // cardTotalProducts
            // 
            this.cardTotalProducts.BackColor = System.Drawing.Color.Transparent;
            this.cardTotalProducts.BorderRadius = 20;
            this.cardTotalProducts.Controls.Add(this.pbIcon1);
            this.cardTotalProducts.Controls.Add(this.lblTitle1);
            this.cardTotalProducts.Controls.Add(this.lblVal1);
            this.cardTotalProducts.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(82)))), ((int)(((byte)(255)))));
            this.cardTotalProducts.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(55)))));
            this.cardTotalProducts.Location = new System.Drawing.Point(20, 20);
            this.cardTotalProducts.Name = "cardTotalProducts";
            this.cardTotalProducts.ShadowDecoration.BorderRadius = 20;
            this.cardTotalProducts.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(82)))), ((int)(((byte)(255)))));
            this.cardTotalProducts.ShadowDecoration.Depth = 15;
            this.cardTotalProducts.ShadowDecoration.Enabled = true;
            this.cardTotalProducts.Size = new System.Drawing.Size(230, 110);
            this.cardTotalProducts.TabIndex = 6;
            // 
            // pbIcon1
            // 
            this.pbIcon1.ImageRotate = 0F;
            this.pbIcon1.Location = new System.Drawing.Point(15, 25);
            this.pbIcon1.Name = "pbIcon1";
            this.pbIcon1.Size = new System.Drawing.Size(50, 50);
            this.pbIcon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon1.TabIndex = 2;
            this.pbIcon1.TabStop = false;
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblTitle1.Location = new System.Drawing.Point(80, 25);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(87, 15);
            this.lblTitle1.TabIndex = 3;
            this.lblTitle1.Text = "إجمالي المنتجات";
            // 
            // lblVal1
            // 
            this.lblVal1.AutoSize = true;
            this.lblVal1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblVal1.ForeColor = System.Drawing.Color.White;
            this.lblVal1.Location = new System.Drawing.Point(80, 45);
            this.lblVal1.Name = "lblVal1";
            this.lblVal1.Size = new System.Drawing.Size(35, 41);
            this.lblVal1.TabIndex = 4;
            this.lblVal1.Text = "0";
            // 
            // cardLowStock
            // 
            this.cardLowStock.BackColor = System.Drawing.Color.Transparent;
            this.cardLowStock.BorderRadius = 20;
            this.cardLowStock.Controls.Add(this.pbIcon2);
            this.cardLowStock.Controls.Add(this.lblTitle2);
            this.cardLowStock.Controls.Add(this.lblVal2);
            this.cardLowStock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.cardLowStock.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(55)))));
            this.cardLowStock.Location = new System.Drawing.Point(265, 20);
            this.cardLowStock.Name = "cardLowStock";
            this.cardLowStock.ShadowDecoration.BorderRadius = 20;
            this.cardLowStock.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.cardLowStock.ShadowDecoration.Depth = 15;
            this.cardLowStock.ShadowDecoration.Enabled = true;
            this.cardLowStock.Size = new System.Drawing.Size(230, 110);
            this.cardLowStock.TabIndex = 5;
            // 
            // pbIcon2
            // 
            this.pbIcon2.ImageRotate = 0F;
            this.pbIcon2.Location = new System.Drawing.Point(15, 25);
            this.pbIcon2.Name = "pbIcon2";
            this.pbIcon2.Size = new System.Drawing.Size(50, 50);
            this.pbIcon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon2.TabIndex = 2;
            this.pbIcon2.TabStop = false;
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblTitle2.Location = new System.Drawing.Point(80, 25);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(84, 15);
            this.lblTitle2.TabIndex = 3;
            this.lblTitle2.Text = "نواقص المخزون";
            // 
            // lblVal2
            // 
            this.lblVal2.AutoSize = true;
            this.lblVal2.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblVal2.ForeColor = System.Drawing.Color.White;
            this.lblVal2.Location = new System.Drawing.Point(80, 45);
            this.lblVal2.Name = "lblVal2";
            this.lblVal2.Size = new System.Drawing.Size(35, 41);
            this.lblVal2.TabIndex = 4;
            this.lblVal2.Text = "0";
            // 
            // cardTotalSales
            // 
            this.cardTotalSales.BackColor = System.Drawing.Color.Transparent;
            this.cardTotalSales.BorderRadius = 20;
            this.cardTotalSales.Controls.Add(this.pbIcon3);
            this.cardTotalSales.Controls.Add(this.lblTitle3);
            this.cardTotalSales.Controls.Add(this.lblVal3);
            this.cardTotalSales.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.cardTotalSales.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(55)))));
            this.cardTotalSales.Location = new System.Drawing.Point(510, 20);
            this.cardTotalSales.Name = "cardTotalSales";
            this.cardTotalSales.ShadowDecoration.BorderRadius = 20;
            this.cardTotalSales.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.cardTotalSales.ShadowDecoration.Depth = 15;
            this.cardTotalSales.ShadowDecoration.Enabled = true;
            this.cardTotalSales.Size = new System.Drawing.Size(230, 110);
            this.cardTotalSales.TabIndex = 4;
            // 
            // pbIcon3
            // 
            this.pbIcon3.ImageRotate = 0F;
            this.pbIcon3.Location = new System.Drawing.Point(15, 25);
            this.pbIcon3.Name = "pbIcon3";
            this.pbIcon3.Size = new System.Drawing.Size(50, 50);
            this.pbIcon3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon3.TabIndex = 2;
            this.pbIcon3.TabStop = false;
            // 
            // lblTitle3
            // 
            this.lblTitle3.AutoSize = true;
            this.lblTitle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblTitle3.Location = new System.Drawing.Point(80, 25);
            this.lblTitle3.Name = "lblTitle3";
            this.lblTitle3.Size = new System.Drawing.Size(87, 15);
            this.lblTitle3.TabIndex = 3;
            this.lblTitle3.Text = "إجمالي المبيعات";
            // 
            // lblVal3
            // 
            this.lblVal3.AutoSize = true;
            this.lblVal3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblVal3.ForeColor = System.Drawing.Color.White;
            this.lblVal3.Location = new System.Drawing.Point(80, 48);
            this.lblVal3.Name = "lblVal3";
            this.lblVal3.Size = new System.Drawing.Size(78, 32);
            this.lblVal3.TabIndex = 4;
            this.lblVal3.Text = "$0.00";
            // 
            // cardOrders
            // 
            this.cardOrders.BackColor = System.Drawing.Color.Transparent;
            this.cardOrders.BorderRadius = 20;
            this.cardOrders.Controls.Add(this.pbIcon4);
            this.cardOrders.Controls.Add(this.lblTitle4);
            this.cardOrders.Controls.Add(this.lblVal4);
            this.cardOrders.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.cardOrders.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(55)))));
            this.cardOrders.Location = new System.Drawing.Point(755, 20);
            this.cardOrders.Name = "cardOrders";
            this.cardOrders.ShadowDecoration.BorderRadius = 20;
            this.cardOrders.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.cardOrders.ShadowDecoration.Depth = 15;
            this.cardOrders.ShadowDecoration.Enabled = true;
            this.cardOrders.Size = new System.Drawing.Size(230, 110);
            this.cardOrders.TabIndex = 3;
            // 
            // pbIcon4
            // 
            this.pbIcon4.ImageRotate = 0F;
            this.pbIcon4.Location = new System.Drawing.Point(15, 25);
            this.pbIcon4.Name = "pbIcon4";
            this.pbIcon4.Size = new System.Drawing.Size(50, 50);
            this.pbIcon4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon4.TabIndex = 2;
            this.pbIcon4.TabStop = false;
            // 
            // lblTitle4
            // 
            this.lblTitle4.AutoSize = true;
            this.lblTitle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblTitle4.Location = new System.Drawing.Point(80, 25);
            this.lblTitle4.Name = "lblTitle4";
            this.lblTitle4.Size = new System.Drawing.Size(80, 15);
            this.lblTitle4.TabIndex = 3;
            this.lblTitle4.Text = "الطلبات الأخيرة";
            // 
            // lblVal4
            // 
            this.lblVal4.AutoSize = true;
            this.lblVal4.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblVal4.ForeColor = System.Drawing.Color.White;
            this.lblVal4.Location = new System.Drawing.Point(80, 45);
            this.lblVal4.Name = "lblVal4";
            this.lblVal4.Size = new System.Drawing.Size(35, 41);
            this.lblVal4.TabIndex = 4;
            this.lblVal4.Text = "0";
            // 
            // dgvRecentActivity
            // 
            this.dgvRecentActivity.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.dgvRecentActivity.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRecentActivity.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecentActivity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRecentActivity.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecentActivity.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRecentActivity.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.dgvRecentActivity.Location = new System.Drawing.Point(20, 455);
            this.dgvRecentActivity.Name = "dgvRecentActivity";
            this.dgvRecentActivity.ReadOnly = true;
            this.dgvRecentActivity.RowHeadersVisible = false;
            this.dgvRecentActivity.RowTemplate.Height = 40;
            this.dgvRecentActivity.Size = new System.Drawing.Size(965, 180);
            this.dgvRecentActivity.TabIndex = 7;
            this.dgvRecentActivity.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.dgvRecentActivity.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRecentActivity.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRecentActivity.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRecentActivity.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRecentActivity.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
            this.dgvRecentActivity.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.dgvRecentActivity.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.dgvRecentActivity.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecentActivity.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgvRecentActivity.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRecentActivity.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecentActivity.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvRecentActivity.ThemeStyle.ReadOnly = true;
            this.dgvRecentActivity.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.dgvRecentActivity.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecentActivity.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgvRecentActivity.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRecentActivity.ThemeStyle.RowsStyle.Height = 40;
            this.dgvRecentActivity.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecentActivity.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // panelChart1
            // 
            this.panelChart1.BackColor = System.Drawing.Color.Transparent;
            this.panelChart1.BorderRadius = 15;
            this.panelChart1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panelChart1.Location = new System.Drawing.Point(20, 150);
            this.panelChart1.Name = "panelChart1";
            this.panelChart1.ShadowDecoration.Depth = 5;
            this.panelChart1.ShadowDecoration.Enabled = true;
            this.panelChart1.Size = new System.Drawing.Size(475, 250);
            this.panelChart1.TabIndex = 2;
            // 
            // panelChart2
            // 
            this.panelChart2.BackColor = System.Drawing.Color.Transparent;
            this.panelChart2.BorderRadius = 15;
            this.panelChart2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panelChart2.Location = new System.Drawing.Point(510, 150);
            this.panelChart2.Name = "panelChart2";
            this.panelChart2.ShadowDecoration.Depth = 5;
            this.panelChart2.ShadowDecoration.Enabled = true;
            this.panelChart2.Size = new System.Drawing.Size(475, 250);
            this.panelChart2.TabIndex = 1;
            // 
            // lblTableTitle
            // 
            this.lblTableTitle.AutoSize = true;
            this.lblTableTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTableTitle.ForeColor = System.Drawing.Color.White;
            this.lblTableTitle.Location = new System.Drawing.Point(20, 420);
            this.lblTableTitle.Name = "lblTableTitle";
            this.lblTableTitle.Size = new System.Drawing.Size(126, 21);
            this.lblTableTitle.TabIndex = 0;
            this.lblTableTitle.Text = "آخر نشاط للمخزون";
            // 
            // DashboardForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1040, 655);
            this.Controls.Add(this.lblTableTitle);
            this.Controls.Add(this.panelChart2);
            this.Controls.Add(this.panelChart1);
            this.Controls.Add(this.cardOrders);
            this.Controls.Add(this.cardTotalSales);
            this.Controls.Add(this.cardLowStock);
            this.Controls.Add(this.cardTotalProducts);
            this.Controls.Add(this.dgvRecentActivity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DASHBOARD";
            this.cardTotalProducts.ResumeLayout(false);
            this.cardTotalProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon1)).EndInit();
            this.cardLowStock.ResumeLayout(false);
            this.cardLowStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon2)).EndInit();
            this.cardTotalSales.ResumeLayout(false);
            this.cardTotalSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon3)).EndInit();
            this.cardOrders.ResumeLayout(false);
            this.cardOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Guna.UI2.WinForms.Guna2GradientPanel cardTotalProducts;
        private Guna.UI2.WinForms.Guna2PictureBox pbIcon1;
        private Guna.UI2.WinForms.Guna2GradientPanel cardLowStock;
        private Guna.UI2.WinForms.Guna2PictureBox pbIcon2;
        private Guna.UI2.WinForms.Guna2GradientPanel cardTotalSales;
        private Guna.UI2.WinForms.Guna2PictureBox pbIcon3;
        private Guna.UI2.WinForms.Guna2GradientPanel cardOrders;
        private Guna.UI2.WinForms.Guna2PictureBox pbIcon4;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRecentActivity;
        private Guna.UI2.WinForms.Guna2Panel panelChart1;
        private Guna.UI2.WinForms.Guna2Panel panelChart2;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label lblVal1;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblVal2;
        private System.Windows.Forms.Label lblTitle3;
        private System.Windows.Forms.Label lblVal3;
        private System.Windows.Forms.Label lblTitle4;
        private System.Windows.Forms.Label lblVal4;
        private System.Windows.Forms.Label lblTableTitle;
    }
}
