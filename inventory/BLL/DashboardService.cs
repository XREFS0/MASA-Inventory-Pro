using System;
using System.Data;
using inventory.DAL;
using inventory.Helpers;

namespace inventory.BLL
{
    public class DashboardService
    {
        public dynamic GetDashboardStats()
        {
            string sql = @"
                SELECT 
                    (SELECT COUNT(*) FROM Products) as TotalProducts,
                    (SELECT COUNT(*) FROM Products WHERE StockQuantity <= MinStockAlert) as LowStockCount,
                    (SELECT SUM(TotalAmount) FROM Sales WHERE SaleDate >= date('now', '-30 days')) as TotalSales30Days,
                    (SELECT COUNT(*) FROM Sales WHERE SaleDate >= date('now', '-1 day')) as RecentOrders
            ";
            
            DataTable dt = DbHelper.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new {
                    TotalProducts = Convert.ToInt32(row["TotalProducts"]),
                    LowStockCount = Convert.ToInt32(row["LowStockCount"]),
                    TotalSales = row["TotalSales30Days"] == DBNull.Value ? 0 : Convert.ToDouble(row["TotalSales30Days"]),
                    RecentOrders = Convert.ToInt32(row["RecentOrders"])
                };
            }
            return new { TotalProducts = 0, LowStockCount = 0, TotalSales = 0, RecentOrders = 0 };
        }

        public DataTable GetRecentActivity()
        {
            string sql = @"
                SELECT s.Id, 'Sale' as Type, s.CustomerName as Description, s.TotalAmount as Value, s.SaleDate as Date 
                FROM Sales s
                ORDER BY s.SaleDate DESC LIMIT 10";
            return DbHelper.ExecuteQuery(sql);
        }

        public System.Collections.Generic.Dictionary<string, int> GetMonthlySalesData()
        {
            var data = new System.Collections.Generic.Dictionary<string, int>();
            string sql = @"
                SELECT strftime('%m', SaleDate) as Month, SUM(TotalAmount) as Total 
                FROM Sales 
                WHERE SaleDate >= date('now', '-6 months')
                GROUP BY Month ORDER BY Month";
            DataTable dt = DbHelper.ExecuteQuery(sql);
            foreach(DataRow dr in dt.Rows)
            {
                string monthName = new DateTime(2000, Convert.ToInt32(dr["Month"]), 1).ToString("MMM");
                data[monthName] = Convert.ToInt32(Convert.ToDouble(dr["Total"]));
            }
            /* Mock data removed for real results */
            return data;
        }

        public System.Collections.Generic.Dictionary<string, int> GetStockCategoryData()
        {
            var data = new System.Collections.Generic.Dictionary<string, int>();
            string sql = @"
                SELECT c.Name, COUNT(p.Id) as Count 
                FROM Categories c
                LEFT JOIN Products p ON p.CategoryId = c.Id
                GROUP BY c.Name LIMIT 5";
            DataTable dt = DbHelper.ExecuteQuery(sql);
            foreach(DataRow dr in dt.Rows)
            {
                data[dr["Name"].ToString()] = Convert.ToInt32(dr["Count"]);
            }
            /* Mock data removed */
            return data;
        }
    }
}
