using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace inventory.Helpers
{
    public static class ThemeManager
    {
        // Premium Dark Palette
        public static Color DarkBackground = Color.FromArgb(15, 19, 34); // Deep Space Blue
        public static Color DarkPanel = Color.FromArgb(26, 31, 55);      // Glassy Dark
        public static Color DarkHeader = Color.FromArgb(26, 31, 55);
        public static Color DarkText = Color.White;
        public static Color DarkSubText = Color.FromArgb(150, 160, 190);
        public static Color DarkAccent = Color.FromArgb(140, 82, 255);   // Premium Purple/Violet

        public static void ApplyTheme(Form form)
        {
            Color bg = DarkBackground;
            Color panelBg = DarkPanel;
            Color text = DarkText;
            Color subText = DarkSubText;

            form.BackColor = bg;

            foreach (Control ctrl in form.Controls)
            {
                ApplyToControl(ctrl, bg, panelBg, text, subText);
            }
        }

        private static void ApplyToControl(Control ctrl, Color bg, Color panelBg, Color text, Color subText)
        {
            if (ctrl is Guna2Panel panel)
            {
                panel.FillColor = panelBg;
            }
            else if (ctrl is Label lbl)
            {
                if (lbl.ForeColor == DarkSubText)
                    lbl.ForeColor = subText;
                else
                    lbl.ForeColor = text;
            }
            else if (ctrl is Guna2Button btn)
            {
                // If button was blue or is tagged as Accent, change to DarkAccent
                if (btn.FillColor == Color.FromArgb(64, 123, 255) || (btn.Tag != null && btn.Tag.ToString() == "Accent"))
                {
                    btn.FillColor = DarkAccent;
                }
                btn.ForeColor = text;
            }
            else if (ctrl is Guna2DataGridView dgv)
            {
                // Force background color to match the dark theme
                dgv.BackgroundColor = bg;
                dgv.GridColor = Color.FromArgb(45, 52, 71);
                
                // Use Default to allow full manual control
                dgv.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
                
                // 1. Set Global Selection Style
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(50, DarkAccent.R, DarkAccent.G, DarkAccent.B); // Subtle selection
                dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(50, DarkAccent.R, DarkAccent.G, DarkAccent.B);
                dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

                // 2. Styling for all columns
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    col.DefaultCellStyle.BackColor = Color.FromArgb(25, 29, 43);
                    col.DefaultCellStyle.ForeColor = Color.White;
                    
                    // Special styling for Image Columns (Edit/Delete)
                    if (col is DataGridViewImageColumn imgCol)
                    {
                        imgCol.DefaultCellStyle.Padding = new Padding(12);
                        imgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    }
                }

                // 3. Set ThemeStyle properties for rows
                dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(60, 60, 90);
                dgv.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
                dgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(60, 60, 90);
                dgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.White;
                
                dgv.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(25, 29, 43);
                dgv.ThemeStyle.RowsStyle.ForeColor = Color.White;
                dgv.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(30, 35, 51);
                dgv.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.White;
                
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
                
                // 4. Header Styling (Aggressive Fix)
                Color headerColor = Color.FromArgb(36, 43, 61);
                dgv.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersHeight = 45;
                
                dgv.ThemeStyle.HeaderStyle.BackColor = headerColor;
                dgv.ThemeStyle.HeaderStyle.ForeColor = Color.White;
                dgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 10F);
                
                dgv.EnableHeadersVisualStyles = false;
                dgv.RowTemplate.Height = 50;
                dgv.MultiSelect = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.BorderStyle = BorderStyle.None;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                // Auto-register premium button drawing if columns exist
                dgv.CellPainting -= DrawActionButtons;
                dgv.CellPainting += DrawActionButtons;
            }

            if (ctrl.HasChildren)
            {
                foreach (Control child in ctrl.Controls)
                {
                    ApplyToControl(child, bg, panelBg, text, subText);
                }
            }
        }
        public static void DrawActionButtons(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridView dgv = sender as DataGridView;
            string colName = dgv.Columns[e.ColumnIndex].Name;

            if (colName == "Edit" || colName == "Delete" || colName == "DeleteAll")
            {
                // Draw background and borders
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                // Premium Colors (Matching UI palette)
                Color themeColor;
                if (colName == "Edit")
                    themeColor = Color.FromArgb(255, 180, 0); // Amber
                else if (colName == "Delete")
                    themeColor = Color.FromArgb(244, 67, 54); // Soft Red
                else
                    themeColor = Color.FromArgb(211, 47, 47); // Deep Red

                // Define drawing area
                int iconSize = 28;
                int x = e.CellBounds.X + (e.CellBounds.Width - iconSize) / 2;
                int y = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;

                // Robust Icon Retrieval
                Image img = e.Value as Image;
                if (img == null && dgv.Columns[e.ColumnIndex] is DataGridViewImageColumn imgCol)
                {
                    img = imgCol.Image;
                }

                // EMERGENCY FALLBACK: Load from disk if image is still null
                if (img == null)
                {
                    try {
                        string path = Application.StartupPath;
                        // Search up for Assets folder (common in dev environment)
                        for (int i = 0; i < 5; i++) {
                            if (Directory.Exists(Path.Combine(path, "Assets"))) break;
                            path = Path.GetDirectoryName(path);
                            if (path == null) break;
                        }
                        if (path != null) {
                            string fileName = colName + ".png"; // Dynamic based on column name
                            string fullPath = Path.Combine(path, "Assets", "Images", fileName);
                            if (File.Exists(fullPath)) img = Image.FromFile(fullPath);
                        }
                    } catch { }
                }

                // Draw Icon with the specific theme color
                if (img != null)
                {
                    using (var attributes = new System.Drawing.Imaging.ImageAttributes())
                    {
                        // Color Matrix to transform ANY icon color to the specific theme color
                        float r = themeColor.R / 255f;
                        float g = themeColor.G / 255f;
                        float b = themeColor.B / 255f;

                        float[][] matrixItems = {
                            new float[] {0, 0, 0, 0, 0},
                            new float[] {0, 0, 0, 0, 0},
                            new float[] {0, 0, 0, 0, 0},
                            new float[] {0, 0, 0, 0, 1}, 
                            new float[] {r, g, b, 0, 1}  
                        };
                        var colorMatrix = new System.Drawing.Imaging.ColorMatrix(matrixItems);
                        attributes.SetColorMatrix(colorMatrix);

                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        e.Graphics.DrawImage(img, new Rectangle(x, y, iconSize, iconSize), 
                            0, 0, img.Width, img.Height, GraphicsUnit.Pixel, attributes);
                    }
                }
                else
                {
                    // If STILL null, draw a small circle placeholder so the user can at least click it
                    using (var brush = new SolidBrush(themeColor))
                    {
                        e.Graphics.FillEllipse(brush, new Rectangle(x + 4, y + 4, iconSize - 8, iconSize - 8));
                    }
                }

                e.Handled = true;
            }
        }
    }
}
