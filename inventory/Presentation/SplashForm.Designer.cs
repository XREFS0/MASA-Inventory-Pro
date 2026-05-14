namespace inventory.Presentation
{
    partial class SplashForm
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
            this.pbLoading = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.picLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblLoading = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblMasa = new System.Windows.Forms.Label();
            this.lblInventoryPro = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            // SplashForm Properties
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(800, 500); // Increased height slightly
            this.BackColor = System.Drawing.Color.FromArgb(10, 15, 30);
            try {
                this.BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\Administrator\source\repos\inventory\inventory\Assets\Images\back.png");
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            } catch { }

            // picLogo (The M Icon)
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            try {
                this.picLogo.Image = System.Drawing.Image.FromFile(@"C:\Users\Administrator\source\repos\inventory\inventory\Assets\Images\logo2.png");
            } catch { }
            this.picLogo.Location = new System.Drawing.Point(325, 40);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(150, 150);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;

            // lblMasa
            this.lblMasa.BackColor = System.Drawing.Color.Transparent;
            this.lblMasa.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold);
            this.lblMasa.ForeColor = System.Drawing.Color.White;
            this.lblMasa.Location = new System.Drawing.Point(0, 180);
            this.lblMasa.Name = "lblMasa";
            this.lblMasa.Size = new System.Drawing.Size(800, 80);
            this.lblMasa.TabIndex = 3;
            this.lblMasa.Text = "MASA";
            this.lblMasa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblInventoryPro
            this.lblInventoryPro.BackColor = System.Drawing.Color.Transparent;
            this.lblInventoryPro.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblInventoryPro.ForeColor = System.Drawing.Color.FromArgb(212, 175, 55); // Gold
            this.lblInventoryPro.Location = new System.Drawing.Point(0, 255);
            this.lblInventoryPro.Name = "lblInventoryPro";
            this.lblInventoryPro.Size = new System.Drawing.Size(800, 40);
            this.lblInventoryPro.TabIndex = 4;
            this.lblInventoryPro.Text = "Inventory Pro";
            this.lblInventoryPro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlLine (Separator Line)
            this.pnlLine.BackColor = System.Drawing.Color.FromArgb(212, 175, 55);
            this.pnlLine.Location = new System.Drawing.Point(300, 305);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(200, 1);
            this.pnlLine.TabIndex = 5;

            // lblTagline
            this.lblTagline.BackColor = System.Drawing.Color.Transparent;
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(180, 190, 210);
            this.lblTagline.Location = new System.Drawing.Point(0, 315);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(800, 25);
            this.lblTagline.TabIndex = 6;
            this.lblTagline.Text = "نظام إدارة المخزون المتطور";
            this.lblTagline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pbLoading
            this.pbLoading.BorderRadius = 5;
            this.pbLoading.FillColor = System.Drawing.Color.FromArgb(40, 45, 60);
            this.pbLoading.Location = new System.Drawing.Point(200, 420);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.ProgressColor = System.Drawing.Color.FromArgb(212, 175, 55); // Gold
            this.pbLoading.ProgressColor2 = System.Drawing.Color.FromArgb(255, 215, 0); // Brighter Gold
            this.pbLoading.Size = new System.Drawing.Size(400, 8);
            this.pbLoading.TabIndex = 1;

            // lblLoading
            this.lblLoading.BackColor = System.Drawing.Color.Transparent;
            this.lblLoading.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoading.ForeColor = System.Drawing.Color.FromArgb(150, 160, 180);
            this.lblLoading.Location = new System.Drawing.Point(200, 395);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(400, 20);
            this.lblLoading.TabIndex = 2;
            this.lblLoading.Text = "جاري التحميل...";
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Form
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.lblTagline);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.lblInventoryPro);
            this.Controls.Add(this.lblMasa);
            this.Controls.Add(this.picLogo);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2ProgressBar pbLoading;
        private Guna.UI2.WinForms.Guna2PictureBox picLogo;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Label lblMasa;
        private System.Windows.Forms.Label lblInventoryPro;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Panel pnlLine;
    }
}
