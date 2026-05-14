using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace inventory.Helpers
{
    public static class DataSeeder
    {
        public static void SeedAllData()
        {
            try
            {
                // 1. Seed Categories
                SeedCategories();

                // 2. Seed Suppliers
                SeedSuppliers();

                // 3. Seed Products (150 items)
                SeedProducts();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("خطأ أثناء تهيئة البيانات: " + ex.Message, "خطأ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private static void SeedCategories()
        {
            string[] categoriesEn = { "Electronics", "Groceries", "Clothing", "Home & Kitchen", "Pharmacy", "Automotive", "Toys & Games", "Office Supplies" };
            string[] categoriesAr = { "إلكترونيات", "مواد غذائية", "ملابس", "منزل ومطبخ", "صيدلية", "سيارات", "ألعاب", "أدوات مكتبية" };
            
            for (int i = 0; i < categoriesEn.Length; i++)
            {
                string en = categoriesEn[i];
                string ar = categoriesAr[i];

                // 1. Check if Arabic version already exists
                DataTable dtAr = DbHelper.ExecuteQuery($"SELECT Id FROM Categories WHERE Name = '{ar}'");
                DataTable dtEn = DbHelper.ExecuteQuery($"SELECT Id FROM Categories WHERE Name = '{en}'");

                if (dtEn.Rows.Count > 0)
                {
                    int enId = Convert.ToInt32(dtEn.Rows[0]["Id"]);
                    if (dtAr.Rows.Count > 0)
                    {
                        // Arabic exists, move all products from English to Arabic then delete English
                        int arId = Convert.ToInt32(dtAr.Rows[0]["Id"]);
                        DbHelper.ExecuteNonQuery($"UPDATE Products SET CategoryId = {arId} WHERE CategoryId = {enId}");
                        DbHelper.ExecuteNonQuery($"DELETE FROM Categories WHERE Id = {enId}");
                    }
                    else
                    {
                        // Arabic doesn't exist, safe to rename English to Arabic
                        DbHelper.ExecuteNonQuery($"UPDATE Categories SET Name = '{ar}' WHERE Id = {enId}");
                    }
                }
                else if (dtAr.Rows.Count == 0)
                {
                    // Neither exists, insert new Arabic category
                    DbHelper.ExecuteNonQuery($"INSERT INTO Categories (Name, Description) VALUES ('{ar}', 'منتجات {ar} عالية الجودة')");
                }
            }
        }

        private static void SeedSuppliers()
        {
            string[] suppliersEn = { "Global Tech Distribution", "Fresh Harvest Foods", "Elite Fashion Group", "Modern Home Solutions", "HealthFirst Medical", "AutoPart Pro", "ToyWorld Inc", "Stationery Hub" };
            string[] suppliersAr = { "شركة التقنية العالمية", "شركة الحصاد الطازج", "مجموعة النخبة للأزياء", "حلول المنزل الحديثة", "مؤسسة صحتي أولاً", "شركة قطع غيار السيارات", "شركة عالم الألعاب", "مركز الأدوات المكتبية" };
            
            for (int i = 0; i < suppliersEn.Length; i++)
            {
                string en = suppliersEn[i];
                string ar = suppliersAr[i];

                DataTable dtAr = DbHelper.ExecuteQuery($"SELECT Id FROM Suppliers WHERE Name = '{ar}'");
                DataTable dtEn = DbHelper.ExecuteQuery($"SELECT Id FROM Suppliers WHERE Name = '{en}'");

                if (dtEn.Rows.Count > 0)
                {
                    int enId = Convert.ToInt32(dtEn.Rows[0]["Id"]);
                    if (dtAr.Rows.Count > 0)
                    {
                        int arId = Convert.ToInt32(dtAr.Rows[0]["Id"]);
                        DbHelper.ExecuteNonQuery($"UPDATE Products SET SupplierId = {arId} WHERE SupplierId = {enId}");
                        DbHelper.ExecuteNonQuery($"DELETE FROM Suppliers WHERE Id = {enId}");
                    }
                    else
                    {
                        DbHelper.ExecuteNonQuery($"UPDATE Suppliers SET Name = '{ar}' WHERE Id = {enId}");
                    }
                }
                else if (dtAr.Rows.Count == 0)
                {
                    DbHelper.ExecuteNonQuery($"INSERT INTO Suppliers (Name, ContactPerson, Phone, Email, Address) VALUES ('{ar}', 'مدير المبيعات', '0123456789', 'contact@{ar.Replace(" ", "")}.com', 'القاهرة، مصر')");
                }
            }
        }

        private static void SeedProducts()
        {
            DataTable dtCount = DbHelper.ExecuteQuery("SELECT COUNT(*) FROM Products");
            int currentCount = Convert.ToInt32(dtCount.Rows[0][0]);
            
            if (currentCount >= 150) return;

            int toAdd = 150 - currentCount;

            // Get Category IDs
            DataTable dtCats = DbHelper.ExecuteQuery("SELECT Id, Name FROM Categories");
            var catIds = dtCats.AsEnumerable().Select(r => Convert.ToInt32(r["Id"])).ToList();
            
            // Get Supplier IDs
            DataTable dtSups = DbHelper.ExecuteQuery("SELECT Id FROM Suppliers");
            var supIds = dtSups.AsEnumerable().Select(r => Convert.ToInt32(r["Id"])).ToList();

            Random rand = new Random();
            string[] adjectives = { "ممتاز", "فائق", "ذكي", "بيئي", "محترف", "رقمي", "كلاسيكي", "حديث", "متطور", "أساسي" };
            string[] types = { "شاشة", "كرسي", "لابتوب", "عصير", "قميص", "مصباح", "تابلت", "صانع قهوة", "غطاء هاتف", "منظم مكتب" };

            for (int i = 0; i < toAdd; i++)
            {
                string name = $"{adjectives[rand.Next(adjectives.Length)]} {types[rand.Next(types.Length)]} Model {i + 1}";
                string barcode = "BR" + rand.Next(100000, 999999).ToString();
                decimal purchasePrice = rand.Next(10, 500);
                decimal salePrice = purchasePrice * 1.3m;
                int stock = rand.Next(5, 200);
                int minStock = rand.Next(5, 15);
                int catId = catIds[rand.Next(catIds.Count)];
                int supId = supIds[rand.Next(supIds.Count)];

                string query = $"INSERT INTO Products (Name, Barcode, PurchasePrice, SalePrice, StockQuantity, MinStockAlert, CategoryId, SupplierId, CreatedAt) " +
                               $"VALUES ('{name}', '{barcode}', {purchasePrice}, {salePrice}, {stock}, {minStock}, {catId}, {supId}, '{DateTime.Now:yyyy-MM-dd HH:mm:ss}')";
                
                DbHelper.ExecuteNonQuery(query);
            }
        }
    }
}
