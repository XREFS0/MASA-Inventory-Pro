using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using inventory.Models;
using inventory.Helpers;

namespace inventory.DAL
{
    public class SupplierRepository
    {
        public DataTable GetAllSuppliers()
        {
            string sql = "SELECT * FROM Suppliers";
            return DbHelper.ExecuteQuery(sql);
        }

        public bool AddSupplier(Supplier supplier)
        {
            string sql = "INSERT INTO Suppliers (Name, Phone, Email, Address) VALUES (@name, @phone, @email, @address)";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@name", supplier.Name),
                new SQLiteParameter("@phone", supplier.Phone),
                new SQLiteParameter("@email", supplier.Email),
                new SQLiteParameter("@address", supplier.Address)
            };
            return DbHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool DeleteSupplier(int id)
        {
            string sql = "DELETE FROM Suppliers WHERE Id = @id";
            SQLiteParameter[] parameters = { new SQLiteParameter("@id", id) };
            return DbHelper.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}
