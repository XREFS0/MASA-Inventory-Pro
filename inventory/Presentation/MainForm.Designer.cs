namespace inventory.Presentation
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sidebarPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSelectionIndicator = new Guna.UI2.WinForms.Guna2Panel();
            this.btnHelp = new Guna.UI2.WinForms.Guna2Button();
            this.btnOrders = new Guna.UI2.WinForms.Guna2Button();
            this.btnSuppliers = new Guna.UI2.WinForms.Guna2Button();
            this.btnCategories = new Guna.UI2.WinForms.Guna2Button();
            this.btnProducts = new Guna.UI2.WinForms.Guna2Button();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.headerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            this.sidebarPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.Transparent;
            this.sidebarPanel.Controls.Add(this.pnlSelectionIndicator);
            this.sidebarPanel.Controls.Add(this.btnHelp);
            this.sidebarPanel.Controls.Add(this.btnOrders);
            this.sidebarPanel.Controls.Add(this.btnSuppliers);
            this.sidebarPanel.Controls.Add(this.btnCategories);
            this.sidebarPanel.Controls.Add(this.btnProducts);
            this.sidebarPanel.Controls.Add(this.btnDashboard);
            this.guna2Transition1.SetDecoration(this.sidebarPanel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(34)))));
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(240, 720);
            this.sidebarPanel.TabIndex = 2;
            // 
            // pnlSelectionIndicator
            // 
            this.pnlSelectionIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(82)))), ((int)(((byte)(255)))));
            this.guna2Transition1.SetDecoration(this.pnlSelectionIndicator, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlSelectionIndicator.Location = new System.Drawing.Point(0, 100);
            this.pnlSelectionIndicator.Name = "pnlSelectionIndicator";
            this.pnlSelectionIndicator.Size = new System.Drawing.Size(5, 50);
            this.pnlSelectionIndicator.TabIndex = 7;
            // 
            // btnHelp
            // 
            this.btnHelp.Animated = true;
            this.btnHelp.BorderRadius = 12;
            this.guna2Transition1.SetDecoration(this.btnHelp, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnHelp.FillColor = System.Drawing.Color.Transparent;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.btnHelp.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(55)))));
            this.btnHelp.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnHelp.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnHelp.ImageSize = new System.Drawing.Size(24, 24);
            this.btnHelp.Location = new System.Drawing.Point(15, 660);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(210, 50);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.Text = "المساعدة";
            this.btnHelp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHelp.TextOffset = new System.Drawing.Point(30, 0);
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Transition1.SetDecoration(this.btnOrders, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnOrders.FillColor = System.Drawing.Color.Transparent;
            this.btnOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.btnOrders.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnOrders.ImageSize = new System.Drawing.Size(24, 24);
            this.btnOrders.Location = new System.Drawing.Point(15, 220);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(210, 50);
            this.btnOrders.TabIndex = 4;
            this.btnOrders.Text = "الطلبات";
            this.btnOrders.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnOrders.TextOffset = new System.Drawing.Point(30, 0);
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Animated = true;
            this.btnSuppliers.BorderRadius = 12;
            this.btnSuppliers.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Transition1.SetDecoration(this.btnSuppliers, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnSuppliers.FillColor = System.Drawing.Color.Transparent;
            this.btnSuppliers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.btnSuppliers.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnSuppliers.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSuppliers.Location = new System.Drawing.Point(15, 340);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(210, 50);
            this.btnSuppliers.TabIndex = 9;
            this.btnSuppliers.Text = "الموردين";
            this.btnSuppliers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSuppliers.TextOffset = new System.Drawing.Point(30, 0);
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.Animated = true;
            this.btnCategories.BorderRadius = 12;
            this.btnCategories.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Transition1.SetDecoration(this.btnCategories, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnCategories.FillColor = System.Drawing.Color.Transparent;
            this.btnCategories.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.btnCategories.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnCategories.ImageSize = new System.Drawing.Size(24, 24);
            this.btnCategories.Location = new System.Drawing.Point(15, 280);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(210, 50);
            this.btnCategories.TabIndex = 8;
            this.btnCategories.Text = "الأقسام";
            this.btnCategories.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCategories.TextOffset = new System.Drawing.Point(30, 0);
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Animated = true;
            this.btnProducts.BorderRadius = 12;
            this.btnProducts.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Transition1.SetDecoration(this.btnProducts, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnProducts.FillColor = System.Drawing.Color.Transparent;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.btnProducts.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnProducts.ImageSize = new System.Drawing.Size(24, 24);
            this.btnProducts.Location = new System.Drawing.Point(15, 160);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(210, 50);
            this.btnProducts.TabIndex = 5;
            this.btnProducts.Text = "المنتجات";
            this.btnProducts.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProducts.TextOffset = new System.Drawing.Point(30, 0);
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Animated = true;
            this.btnDashboard.BorderRadius = 12;
            this.btnDashboard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDashboard.Checked = true;
            this.btnDashboard.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(55)))));
            this.btnDashboard.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.guna2Transition1.SetDecoration(this.btnDashboard, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnDashboard.FillColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.btnDashboard.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(55)))));
            this.btnDashboard.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnDashboard.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDashboard.Location = new System.Drawing.Point(15, 100);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(210, 50);
            this.btnDashboard.TabIndex = 6;
            this.btnDashboard.Text = "لوحة التحكم";
            this.btnDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.TextOffset = new System.Drawing.Point(30, 0);
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel.Controls.Add(this.guna2ControlBox3);
            this.headerPanel.Controls.Add(this.guna2ControlBox2);
            this.headerPanel.Controls.Add(this.guna2ControlBox1);
            this.headerPanel.Controls.Add(this.lblHeaderTitle);
            this.guna2Transition1.SetDecoration(this.headerPanel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(55)))));
            this.headerPanel.Location = new System.Drawing.Point(240, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1040, 70);
            this.headerPanel.TabIndex = 1;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2Transition1.SetDecoration(this.guna2ControlBox3, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox3.Location = new System.Drawing.Point(955, 10);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(35, 30);
            this.guna2ControlBox3.TabIndex = 0;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2Transition1.SetDecoration(this.guna2ControlBox2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(915, 10);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(35, 30);
            this.guna2ControlBox2.TabIndex = 1;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Transition1.SetDecoration(this.guna2ControlBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(995, 10);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(35, 30);
            this.guna2ControlBox1.TabIndex = 2;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.lblHeaderTitle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 25);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(109, 21);
            this.lblHeaderTitle.TabIndex = 5;
            this.lblHeaderTitle.Text = "لوحة التحكم";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "MASA Inventory Pro";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(34)))));
            this.guna2Transition1.SetDecoration(this.mainPanel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(240, 70);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1040, 650);
            this.mainPanel.TabIndex = 0;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.headerPanel;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation1;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.sidebarPanel);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.sidebarPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel sidebarPanel;
        private Guna.UI2.WinForms.Guna2Panel headerPanel;
        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2Button btnProducts;
        private Guna.UI2.WinForms.Guna2Button btnOrders;
        private Guna.UI2.WinForms.Guna2Button btnCategories;
        private Guna.UI2.WinForms.Guna2Button btnSuppliers;
        private Guna.UI2.WinForms.Guna2Button btnHelp;
        private System.Windows.Forms.Label lblHeaderTitle;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
        private Guna.UI2.WinForms.Guna2Panel pnlSelectionIndicator;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}
