using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using inventory.Models;
using inventory.Helpers;

namespace inventory.DAL
{
    public class SalesRepository
    {
        public bool CreateSale(Sale sale, List<SaleItem> items)
        {
            using (var connection = new SQLiteConnection(DbHelper.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try {
                        string saleSql = "INSERT INTO Sales (SaleDate, TotalAmount, Discount, GrandTotal, UserId, CustomerName) VALUES (@date, @total, @disc, @grand, @user, @cust); SELECT last_insert_rowid();";
                        long saleId;
                        using (var cmd = new SQLiteCommand(saleSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@date", sale.SaleDate);
                            cmd.Parameters.AddWithValue("@total", sale.TotalAmount);
                            cmd.Parameters.AddWithValue("@disc", sale.Discount);
                            cmd.Parameters.AddWithValue("@grand", sale.GrandTotal);
                            cmd.Parameters.AddWithValue("@user", sale.UserId);
                            cmd.Parameters.AddWithValue("@cust", sale.CustomerName);
                            saleId = (long)cmd.ExecuteScalar();
                        }

                        foreach (var item in items)
                        {
                            string itemSql = "INSERT INTO SaleItems (SaleId, ProductId, Quantity, UnitPrice, TotalPrice) VALUES (@saleId, @prodId, @qty, @price, @total)";
                            using (var cmd = new SQLiteCommand(itemSql, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@saleId", saleId);
                                cmd.Parameters.AddWithValue("@prodId", item.ProductId);
                                cmd.Parameters.AddWithValue("@qty", item.Quantity);
                                cmd.Parameters.AddWithValue("@price", item.UnitPrice);
                                cmd.Parameters.AddWithValue("@total", item.TotalPrice);
                                cmd.ExecuteNonQuery();
                            }

                            // Update Stock
                            string stockSql = "UPDATE Products SET StockQuantity = StockQuantity - @qty WHERE Id = @prodId";
                            using (var cmd = new SQLiteCommand(stockSql, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@qty", item.Quantity);
                                cmd.Parameters.AddWithValue("@prodId", item.ProductId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    } catch {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public DataTable GetAllSales()
        {
            string sql = @"
                SELECT s.Id, s.SaleDate, s.CustomerName, s.TotalAmount, s.Discount, s.GrandTotal, u.FullName as Salesman
                FROM Sales s
                LEFT JOIN Users u ON s.UserId = u.Id
                ORDER BY s.SaleDate DESC";
            return DbHelper.ExecuteQuery(sql);
        }

        public bool DeleteSale(int saleId)
        {
            using (var connection = new SQLiteConnection(DbHelper.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try {
                        // 1. Get items to restore stock
                        string getItemsSql = "SELECT ProductId, Quantity FROM SaleItems WHERE SaleId = @saleId";
                        using (var cmd = new SQLiteCommand(getItemsSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@saleId", saleId);
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int prodId = reader.GetInt32(0);
                                    int qty = reader.GetInt32(1);
                                    
                                    // Restore stock
                                    string restoreSql = "UPDATE Products SET StockQuantity = StockQuantity + @qty WHERE Id = @prodId";
                                    using (var updateCmd = new SQLiteCommand(restoreSql, connection, transaction))
                                    {
                                        updateCmd.Parameters.AddWithValue("@qty", qty);
                                        updateCmd.Parameters.AddWithValue("@prodId", prodId);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // 2. Delete items and sale
                        string deleteItemsSql = "DELETE FROM SaleItems WHERE SaleId = @saleId";
                        using (var cmd = new SQLiteCommand(deleteItemsSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@saleId", saleId);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteSaleSql = "DELETE FROM Sales WHERE Id = @saleId";
                        using (var cmd = new SQLiteCommand(deleteSaleSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@saleId", saleId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    } catch {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        public Sale GetSaleById(int saleId)
        {
            string sql = "SELECT * FROM Sales WHERE Id = @id";
            DataTable dt = DbHelper.ExecuteQuery(sql, new SQLiteParameter[] { new SQLiteParameter("@id", saleId) });
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new Sale {
                    Id = Convert.ToInt32(row["Id"]),
                    SaleDate = Convert.ToDateTime(row["SaleDate"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    Discount = Convert.ToDecimal(row["Discount"]),
                    GrandTotal = Convert.ToDecimal(row["GrandTotal"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    CustomerName = row["CustomerName"].ToString()
                };
            }
            return null;
        }

        public List<SaleItem> GetSaleItemsBySaleId(int saleId)
        {
            List<SaleItem> items = new List<SaleItem>();
            string sql = "SELECT * FROM SaleItems WHERE SaleId = @id";
            DataTable dt = DbHelper.ExecuteQuery(sql, new SQLiteParameter[] { new SQLiteParameter("@id", saleId) });
            foreach (DataRow row in dt.Rows)
            {
                items.Add(new SaleItem {
                    Id = Convert.ToInt32(row["Id"]),
                    SaleId = Convert.ToInt32(row["SaleId"]),
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    TotalPrice = Convert.ToDecimal(row["TotalPrice"])
                });
            }
            return items;
        }

        public bool UpdateSale(Sale sale, List<SaleItem> items)
        {
            using (var connection = new SQLiteConnection(DbHelper.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try {
                        // 1. Restore old stock
                        string oldItemsSql = "SELECT ProductId, Quantity FROM SaleItems WHERE SaleId = @saleId";
                        using (var cmd = new SQLiteCommand(oldItemsSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@saleId", sale.Id);
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int prodId = reader.GetInt32(0);
                                    int qty = reader.GetInt32(1);
                                    string restoreSql = "UPDATE Products SET StockQuantity = StockQuantity + @qty WHERE Id = @prodId";
                                    using (var upCmd = new SQLiteCommand(restoreSql, connection, transaction))
                                    {
                                        upCmd.Parameters.AddWithValue("@qty", qty);
                                        upCmd.Parameters.AddWithValue("@prodId", prodId);
                                        upCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // 2. Delete old items
                        string deleteSql = "DELETE FROM SaleItems WHERE SaleId = @saleId";
                        using (var cmd = new SQLiteCommand(deleteSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@saleId", sale.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Update Sale details
                        string updateSaleSql = "UPDATE Sales SET SaleDate = @date, TotalAmount = @total, Discount = @disc, GrandTotal = @grand, CustomerName = @cust WHERE Id = @id";
                        using (var cmd = new SQLiteCommand(updateSaleSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@date", sale.SaleDate);
                            cmd.Parameters.AddWithValue("@total", sale.TotalAmount);
                            cmd.Parameters.AddWithValue("@disc", sale.Discount);
                            cmd.Parameters.AddWithValue("@grand", sale.GrandTotal);
                            cmd.Parameters.AddWithValue("@cust", sale.CustomerName);
                            cmd.Parameters.AddWithValue("@id", sale.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Insert new items and deduct stock
                        foreach (var item in items)
                        {
                            string itemSql = "INSERT INTO SaleItems (SaleId, ProductId, Quantity, UnitPrice, TotalPrice) VALUES (@saleId, @prodId, @qty, @price, @total)";
                            using (var cmd = new SQLiteCommand(itemSql, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@saleId", sale.Id);
                                cmd.Parameters.AddWithValue("@prodId", item.ProductId);
                                cmd.Parameters.AddWithValue("@qty", item.Quantity);
                                cmd.Parameters.AddWithValue("@price", item.UnitPrice);
                                cmd.Parameters.AddWithValue("@total", item.TotalPrice);
                                cmd.ExecuteNonQuery();
                            }

                            string deductSql = "UPDATE Products SET StockQuantity = StockQuantity - @qty WHERE Id = @prodId";
                            using (var cmd = new SQLiteCommand(deductSql, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@qty", item.Quantity);
                                cmd.Parameters.AddWithValue("@prodId", item.ProductId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    } catch {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public bool PurgeAllSales()
        {
            using (var connection = new SQLiteConnection(DbHelper.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try {
                        // 1. Restore all stock from all sales (optional, but safer)
                        string restoreSql = @"
                            UPDATE Products 
                            SET StockQuantity = StockQuantity + (
                                SELECT SUM(Quantity) FROM SaleItems WHERE ProductId = Products.Id
                            )
                            WHERE Id IN (SELECT DISTINCT ProductId FROM SaleItems)";
                        using (var cmd = new SQLiteCommand(restoreSql, connection, transaction)) {
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Clear tables
                        new SQLiteCommand("DELETE FROM SaleItems", connection, transaction).ExecuteNonQuery();
                        new SQLiteCommand("DELETE FROM Sales", connection, transaction).ExecuteNonQuery();
                        new SQLiteCommand("DELETE FROM sqlite_sequence WHERE name='Sales' OR name='SaleItems'", connection, transaction).ExecuteNonQuery();

                        transaction.Commit();
                        return true;
                    } catch {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}
