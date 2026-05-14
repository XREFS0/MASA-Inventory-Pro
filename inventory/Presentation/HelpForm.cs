using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace inventory.Presentation
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            LoadLogo();
            ApplyTheme();
        }

        private void LoadLogo()
        {
            try
            {
                string path = Application.StartupPath;
                while (!Directory.Exists(Path.Combine(path, "Assets")) && path.Length > 3)
                {
                    path = Path.GetDirectoryName(path);
                }
                string logoPath = Path.Combine(path, "Assets", "Images", "logo.png");
                
                if (File.Exists(logoPath))
                {
                    pbLogo.Image = Image.FromFile(logoPath);
                }
            }
            catch { }
        }

        private void ApplyTheme()
        {
            Helpers.ThemeManager.ApplyTheme(this);
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button btn && btn.Tag != null)
            {
                try
                {
                    Process.Start(btn.Tag.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("تعذر فتح الرابط: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(Application.StartupPath, "InventoryDB.sqlite");
                if (!File.Exists(dbPath))
                {
                    MessageBox.Show("لم يتم العثور على قاعدة البيانات في المسار: " + dbPath, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.FileName = $"Inventory_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.sqlite";
                    sfd.Filter = "SQLite Database|*.sqlite";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(dbPath, sfd.FileName, true);
                        MessageBox.Show("تم إنشاء نسخة احتياطية بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشلت عملية النسخ الاحتياطي: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
