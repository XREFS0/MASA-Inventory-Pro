using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace inventory.Helpers
{
    public static class LanguageManager
    {
        public enum Language { English }
        public static Language CurrentLanguage { get; set; } = Language.English;

        private static Dictionary<string, string> _translationsAr = new Dictionary<string, string>
        {
            {"Dashboard", "لوحة التحكم"},
            {"Products", "المنتجات"},
            {"Orders", "الطلبات"},
            {"Categories", "الأقسام"},
            {"Suppliers", "الموردين"},
            {"Help", "المساعدة"},
            {"NewOrder", "+ طلب جديد"},
            {"TotalRevenue", "إجمالي الإيرادات"},
            {"TotalOrders", "إجمالي الطلبات"},
            {"TopCustomer", "أفضل عميل"},
            {"RecentOrders", "الطلبات الأخيرة"},
            {"Search", "بحث..."},
            {"ConfirmOrder", "تأكيد الطلب"},
            {"GrandTotal", "الإجمالي النهائي"},
            {"Discount", "الخصم"},
            {"Subtotal", "المجموع الفرعي"},
            {"CustomerName", "اسم العميل"},
            {"SelectProducts", "اختر المنتجات"},
            {"Total", "الإجمالي"},
            {"Quantity", "الكمية"},
            {"Price", "السعر"},
            {"Barcode", "الباركود"},
            {"ProductName", "اسم المنتج"},
            {"Category", "القسم"},
            {"Supplier", "المورد"},
            {"Stock", "المخزون"},
            {"SalePrice", "سعر البيع"},
            {"TotalValue", "القيمة الإجمالية"},
            {"Edit", "تعديل"},
            {"Delete", "حذف"}
        };

        public static string GetString(string key)
        {
            return _translationsAr.ContainsKey(key) ? _translationsAr[key] : key;
        }

        public static void ApplyLanguage(Form form)
        {
            form.RightToLeft = RightToLeft.No;
            TranslateControls(form.Controls);
        }

        private static void TranslateControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl.Tag != null)
                {
                    string key = ctrl.Tag.ToString();
                    if (key == "Accent") continue; // Skip accent theme tag
                    
                    ctrl.Text = GetString(key);
                }

                if (ctrl.HasChildren)
                    TranslateControls(ctrl.Controls);
            }
        }
    }
}
