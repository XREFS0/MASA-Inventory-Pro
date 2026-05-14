using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using inventory.Models;
using inventory.Helpers;

namespace inventory.DAL
{
    public class ProductRepository
    {
        public DataTable GetAllProducts()
        {
            string sql = @"
                SELECT p.*, c.Name as CategoryName, s.Name as SupplierName 
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryId = c.Id
                LEFT JOIN Suppliers s ON p.SupplierId = s.Id";
            return DbHelper.ExecuteQuery(sql);
        }

        public bool AddProduct(Product product)
        {
            string sql = @"INSERT INTO Products (Barcode, Name, Description, CategoryId, SupplierId, PurchasePrice, SalePrice, StockQuantity, MinStockAlert, Unit, ProductImage) 
                           VALUES (@barcode, @name, @desc, @catId, @supId, @pPrice, @sPrice, @stock, @minStock, @unit, @image)";
            
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@barcode", product.Barcode),
                new SQLiteParameter("@name", product.Name),
                new SQLiteParameter("@desc", product.Description),
                new SQLiteParameter("@catId", product.CategoryId),
                new SQLiteParameter("@supId", product.SupplierId),
                new SQLiteParameter("@pPrice", product.PurchasePrice),
                new SQLiteParameter("@sPrice", product.SalePrice),
                new SQLiteParameter("@stock", product.StockQuantity),
                new SQLiteParameter("@minStock", product.MinStockAlert),
                new SQLiteParameter("@unit", product.Unit),
                new SQLiteParameter("@image", product.ProductImage)
            };

            return DbHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool UpdateProduct(Product product)
        {
            string sql = @"UPDATE Products SET Barcode=@barcode, Name=@name, Description=@desc, CategoryId=@catId, SupplierId=@supId, 
                           PurchasePrice=@pPrice, SalePrice=@sPrice, StockQuantity=@stock, MinStockAlert=@minStock, Unit=@unit, ProductImage=@image 
                           WHERE Id=@id";
            
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@barcode", product.Barcode),
                new SQLiteParameter("@name", product.Name),
                new SQLiteParameter("@desc", product.Description),
                new SQLiteParameter("@catId", product.CategoryId),
                new SQLiteParameter("@supId", product.SupplierId),
                new SQLiteParameter("@pPrice", product.PurchasePrice),
                new SQLiteParameter("@sPrice", product.SalePrice),
                new SQLiteParameter("@stock", product.StockQuantity),
                new SQLiteParameter("@minStock", product.MinStockAlert),
                new SQLiteParameter("@unit", product.Unit),
                new SQLiteParameter("@image", product.ProductImage),
                new SQLiteParameter("@id", product.Id)
            };

            return DbHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool DeleteProduct(int id)
        {
            string sql = "DELETE FROM Products WHERE Id = @id";
            SQLiteParameter[] parameters = { new SQLiteParameter("@id", id) };
            return DbHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public Product GetProductById(int id)
        {
            string sql = "SELECT * FROM Products WHERE Id = @id";
            SQLiteParameter[] parameters = { new SQLiteParameter("@id", id) };
            DataTable dt = DbHelper.ExecuteQuery(sql, parameters);
            
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Product
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Barcode = dr["Barcode"].ToString(),
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
                    SupplierId = Convert.ToInt32(dr["SupplierId"]),
                    PurchasePrice = Convert.ToDecimal(dr["PurchasePrice"]),
                    SalePrice = Convert.ToDecimal(dr["SalePrice"]),
                    StockQuantity = Convert.ToInt32(dr["StockQuantity"]),
                    MinStockAlert = Convert.ToInt32(dr["MinStockAlert"]),
                    Unit = dr["Unit"].ToString()
                };
            }
            return null;
        }
        public bool PurgeAllProducts()
        {
            try {
                DbHelper.ExecuteNonQuery("DELETE FROM Products");
                DbHelper.ExecuteNonQuery("DELETE FROM sqlite_sequence WHERE name='Products'");
                return true;
            } catch { return false; }
        }
    }
}
