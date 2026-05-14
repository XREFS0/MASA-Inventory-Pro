namespace inventory.Presentation
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pbLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblCredits = new System.Windows.Forms.Label();
            this.pnlLinks = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTelegram = new Guna.UI2.WinForms.Guna2Button();
            this.btnTelegramChannel = new Guna.UI2.WinForms.Guna2Button();
            this.btnWebsite = new Guna.UI2.WinForms.Guna2Button();
            this.btnYoutube = new Guna.UI2.WinForms.Guna2Button();
            this.btnFacebook = new Guna.UI2.WinForms.Guna2Button();
            this.btnInstagram = new Guna.UI2.WinForms.Guna2Button();
            this.btnGithub = new Guna.UI2.WinForms.Guna2Button();
            this.btnLinkedin = new Guna.UI2.WinForms.Guna2Button();
            this.btnBackup = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlLinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(320, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(191, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "إدارة المخزون";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.lblDescription.Location = new System.Drawing.Point(320, 90);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(600, 80);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "نظام احترافي ومبسط لإدارة المخزون، مصمم للسرعة وسهولة الاستخدام. قم بإدارة منتجات" +
    "ك ومبيعاتك وأقسامك بواجهة مظلمة مميزة.";
            // 
            // pbLogo
            // 
            this.pbLogo.BorderRadius = 20;
            this.pbLogo.ImageRotate = 0F;
            this.pbLogo.Location = new System.Drawing.Point(50, 30);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(240, 240);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 2;
            this.pbLogo.TabStop = false;
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCredits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblCredits.Location = new System.Drawing.Point(320, 190);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(472, 25);
            this.lblCredits.TabIndex = 3;
            this.lblCredits.Text = "تم التطوير بواسطة محمد ممدوح ( MR MASA - XREFS0 )";
            // 
            // pnlLinks
            // 
            this.pnlLinks.AutoScroll = true;
            this.pnlLinks.Controls.Add(this.btnTelegram);
            this.pnlLinks.Controls.Add(this.btnTelegramChannel);
            this.pnlLinks.Controls.Add(this.btnWebsite);
            this.pnlLinks.Controls.Add(this.btnYoutube);
            this.pnlLinks.Controls.Add(this.btnFacebook);
            this.pnlLinks.Controls.Add(this.btnInstagram);
            this.pnlLinks.Controls.Add(this.btnGithub);
            this.pnlLinks.Controls.Add(this.btnLinkedin);
            this.pnlLinks.Controls.Add(this.btnBackup);
            this.pnlLinks.Location = new System.Drawing.Point(320, 240);
            this.pnlLinks.Name = "pnlLinks";
            this.pnlLinks.Size = new System.Drawing.Size(650, 350);
            this.pnlLinks.TabIndex = 4;
            // 
            // btnTelegram
            // 
            this.btnTelegram.Animated = true;
            this.btnTelegram.BorderRadius = 10;
            this.btnTelegram.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnTelegram.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTelegram.ForeColor = System.Drawing.Color.White;
            this.btnTelegram.Location = new System.Drawing.Point(3, 3);
            this.btnTelegram.Name = "btnTelegram";
            this.btnTelegram.Size = new System.Drawing.Size(300, 50);
            this.btnTelegram.TabIndex = 0;
            this.btnTelegram.Tag = "https://t.me/XREFS0";
            this.btnTelegram.Text = "تواصل عبر تيليجرام";
            this.btnTelegram.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnTelegramChannel
            // 
            this.btnTelegramChannel.Animated = true;
            this.btnTelegramChannel.BorderRadius = 10;
            this.btnTelegramChannel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnTelegramChannel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTelegramChannel.ForeColor = System.Drawing.Color.White;
            this.btnTelegramChannel.Location = new System.Drawing.Point(309, 3);
            this.btnTelegramChannel.Name = "btnTelegramChannel";
            this.btnTelegramChannel.Size = new System.Drawing.Size(300, 50);
            this.btnTelegramChannel.TabIndex = 1;
            this.btnTelegramChannel.Tag = "https://t.me/XREFS0_CHANNEL";
            this.btnTelegramChannel.Text = "قناة التيليجرام";
            this.btnTelegramChannel.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnWebsite
            // 
            this.btnWebsite.Animated = true;
            this.btnWebsite.BorderRadius = 10;
            this.btnWebsite.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnWebsite.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnWebsite.ForeColor = System.Drawing.Color.White;
            this.btnWebsite.Location = new System.Drawing.Point(3, 59);
            this.btnWebsite.Name = "btnWebsite";
            this.btnWebsite.Size = new System.Drawing.Size(300, 50);
            this.btnWebsite.TabIndex = 2;
            this.btnWebsite.Tag = "https://xrefs0.blogspot.com/";
            this.btnWebsite.Text = "الموقع الرسمي";
            this.btnWebsite.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnYoutube
            // 
            this.btnYoutube.Animated = true;
            this.btnYoutube.BorderRadius = 10;
            this.btnYoutube.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnYoutube.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnYoutube.ForeColor = System.Drawing.Color.White;
            this.btnYoutube.Location = new System.Drawing.Point(309, 59);
            this.btnYoutube.Name = "btnYoutube";
            this.btnYoutube.Size = new System.Drawing.Size(300, 50);
            this.btnYoutube.TabIndex = 3;
            this.btnYoutube.Tag = "https://www.youtube.com/@XREFS0";
            this.btnYoutube.Text = "قناة اليوتيوب";
            this.btnYoutube.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnFacebook
            // 
            this.btnFacebook.Animated = true;
            this.btnFacebook.BorderRadius = 10;
            this.btnFacebook.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnFacebook.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFacebook.ForeColor = System.Drawing.Color.White;
            this.btnFacebook.Location = new System.Drawing.Point(3, 115);
            this.btnFacebook.Name = "btnFacebook";
            this.btnFacebook.Size = new System.Drawing.Size(300, 50);
            this.btnFacebook.TabIndex = 4;
            this.btnFacebook.Tag = "https://www.facebook.com/MrMasaOfficial";
            this.btnFacebook.Text = "صفحة فيسبوك";
            this.btnFacebook.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnInstagram
            // 
            this.btnInstagram.Animated = true;
            this.btnInstagram.BorderRadius = 10;
            this.btnInstagram.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnInstagram.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInstagram.ForeColor = System.Drawing.Color.White;
            this.btnInstagram.Location = new System.Drawing.Point(309, 115);
            this.btnInstagram.Name = "btnInstagram";
            this.btnInstagram.Size = new System.Drawing.Size(300, 50);
            this.btnInstagram.TabIndex = 5;
            this.btnInstagram.Tag = "https://www.instagram.com/codewithmasa/";
            this.btnInstagram.Text = "إنستغرام";
            this.btnInstagram.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnGithub
            // 
            this.btnGithub.Animated = true;
            this.btnGithub.BorderRadius = 10;
            this.btnGithub.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnGithub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGithub.ForeColor = System.Drawing.Color.White;
            this.btnGithub.Location = new System.Drawing.Point(3, 171);
            this.btnGithub.Name = "btnGithub";
            this.btnGithub.Size = new System.Drawing.Size(300, 50);
            this.btnGithub.TabIndex = 6;
            this.btnGithub.Tag = "https://github.com/XREFS0";
            this.btnGithub.Text = "مستودع جيت هب";
            this.btnGithub.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnLinkedin
            // 
            this.btnLinkedin.Animated = true;
            this.btnLinkedin.BorderRadius = 10;
            this.btnLinkedin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnLinkedin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLinkedin.ForeColor = System.Drawing.Color.White;
            this.btnLinkedin.Location = new System.Drawing.Point(309, 171);
            this.btnLinkedin.Name = "btnLinkedin";
            this.btnLinkedin.Size = new System.Drawing.Size(300, 50);
            this.btnLinkedin.TabIndex = 7;
            this.btnLinkedin.Tag = "https://www.linkedin.com/in/mrmasaofficial";
            this.btnLinkedin.Text = "ملف لينكد إن";
            this.btnLinkedin.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Animated = true;
            this.btnBackup.BorderRadius = 10;
            this.btnBackup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(83)))));
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(3, 227);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(605, 50);
            this.btnBackup.TabIndex = 8;
            this.btnBackup.Text = "نسخة احتياطية للقاعدة (تأمين البيانات)";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlLinks);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HelpForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlLinks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private Guna.UI2.WinForms.Guna2PictureBox pbLogo;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.FlowLayoutPanel pnlLinks;
        private Guna.UI2.WinForms.Guna2Button btnTelegram;
        private Guna.UI2.WinForms.Guna2Button btnTelegramChannel;
        private Guna.UI2.WinForms.Guna2Button btnWebsite;
        private Guna.UI2.WinForms.Guna2Button btnYoutube;
        private Guna.UI2.WinForms.Guna2Button btnFacebook;
        private Guna.UI2.WinForms.Guna2Button btnInstagram;
        private Guna.UI2.WinForms.Guna2Button btnGithub;
        private Guna.UI2.WinForms.Guna2Button btnLinkedin;
        private Guna.UI2.WinForms.Guna2Button btnBackup;
    }
}
