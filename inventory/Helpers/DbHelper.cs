using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace inventory.Helpers
{
    public static class DbHelper
    {
        private static string dbName = "InventoryDB.sqlite";
        private static string connectionString = $"Data Source={dbName};Version=3;";

        public static string ConnectionString => connectionString;

        public static void InitializeDatabase()
        {
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string schema = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT UNIQUE NOT NULL,
                        Password TEXT NOT NULL,
                        FullName TEXT,
                        Role TEXT NOT NULL,
                        CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
                    );

                    CREATE TABLE IF NOT EXISTS Categories (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT UNIQUE NOT NULL,
                        Description TEXT
                    );

                    CREATE TABLE IF NOT EXISTS Suppliers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        ContactPerson TEXT,
                        Phone TEXT,
                        Email TEXT,
                        Address TEXT
                    );

                    CREATE TABLE IF NOT EXISTS Products (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Barcode TEXT UNIQUE,
                        Name TEXT NOT NULL,
                        Description TEXT,
                        CategoryId INTEGER,
                        SupplierId INTEGER,
                        PurchasePrice DECIMAL,
                        SalePrice DECIMAL,
                        StockQuantity INTEGER DEFAULT 0,
                        MinStockAlert INTEGER DEFAULT 5,
                        Unit TEXT,
                        ProductImage BLOB,
                        CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
                        FOREIGN KEY (SupplierId) REFERENCES Suppliers(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Sales (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        SaleDate DATETIME DEFAULT CURRENT_TIMESTAMP,
                        TotalAmount DECIMAL,
                        Discount DECIMAL DEFAULT 0,
                        GrandTotal DECIMAL,
                        CustomerName TEXT,
                        UserId INTEGER,
                        FOREIGN KEY (UserId) REFERENCES Users(Id)
                    );

                    CREATE TABLE IF NOT EXISTS SaleItems (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        SaleId INTEGER,
                        ProductId INTEGER,
                        Quantity INTEGER,
                        UnitPrice DECIMAL,
                        TotalPrice DECIMAL,
                        FOREIGN KEY (SaleId) REFERENCES Sales(Id),
                        FOREIGN KEY (ProductId) REFERENCES Products(Id)
                    );

                    -- Insert default admin if not exists
                    INSERT OR IGNORE INTO Users (Username, Password, FullName, Role) 
                    VALUES ('admin', 'admin123', 'System Administrator', 'Admin');
                ";
                using (var command = new SQLiteCommand(schema, connection))
                {
                    command.ExecuteNonQuery();
                }
                SeedData(connection);
            }
        }

        private static void SeedData(SQLiteConnection conn)
        {
            // Only seed if empty
            string checkSql = "SELECT COUNT(*) FROM Categories";
            using (var cmd = new SQLiteCommand(checkSql, conn))
            {
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0) return;
            }

            string seedSql = @"
                INSERT INTO Categories (Name, Description) VALUES ('Electronics', 'Gadgets and devices');
                INSERT INTO Categories (Name, Description) VALUES ('Groceries', 'Daily food items');
                
                INSERT INTO Suppliers (Name, Phone, Email) VALUES ('Main Distributor', '0123456789', 'info@distro.com');
                
                INSERT INTO Products (Barcode, Name, CategoryId, SupplierId, PurchasePrice, SalePrice, StockQuantity, MinStockAlert, Unit)
                VALUES ('1001', 'Smartphone X', 1, 1, 5000, 7500, 10, 2, 'pcs');
                
                INSERT INTO Products (Barcode, Name, CategoryId, SupplierId, PurchasePrice, SalePrice, StockQuantity, MinStockAlert, Unit)
                VALUES ('1002', 'Laptop Pro', 1, 1, 15000, 22000, 5, 1, 'pcs');

                INSERT INTO Products (Barcode, Name, CategoryId, SupplierId, PurchasePrice, SalePrice, StockQuantity, MinStockAlert, Unit)
                VALUES ('2001', 'Milk 1L', 2, 1, 15, 20, 50, 10, 'bottle');
            ";
            using (var cmd = new SQLiteCommand(seedSql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable ExecuteQuery(string sql, SQLiteParameter[] parameters = null)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static int ExecuteNonQuery(string sql, SQLiteParameter[] parameters = null)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
