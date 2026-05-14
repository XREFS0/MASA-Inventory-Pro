using System.Drawing;
using Guna.UI2.WinForms;

namespace inventory.Helpers
{
    public static class ThemeHelper
    {
        public static bool IsDarkMode { get; private set; } = false;

        public static void ApplyTheme(Form form)
        {
            if (IsDarkMode)
            {
                form.BackColor = Color.FromArgb(32, 33, 36);
                // Recursively apply to controls if needed
            }
            else
            {
                form.BackColor = Color.FromArgb(248, 249, 252);
            }
        }

        public static void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
        }
    }
}
