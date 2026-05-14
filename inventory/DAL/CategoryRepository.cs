using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using inventory.Models;
using inventory.Helpers;

namespace inventory.DAL
{
    public class CategoryRepository
    {
        public DataTable GetAllCategories()
        {
            string sql = "SELECT * FROM Categories";
            return DbHelper.ExecuteQuery(sql);
        }

        public bool AddCategory(Category category)
        {
            string sql = "INSERT INTO Categories (Name, Description) VALUES (@name, @desc)";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@name", category.Name),
                new SQLiteParameter("@desc", category.Description)
            };
            return DbHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool AddCategory(string name)
        {
            string sql = "INSERT INTO Categories (Name) VALUES (@name)";
            SQLiteParameter[] parameters = { new SQLiteParameter("@name", name) };
            return DbHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool DeleteCategory(int id)
        {
            string sql = "DELETE FROM Categories WHERE Id = @id";
            SQLiteParameter[] parameters = { new SQLiteParameter("@id", id) };
            return DbHelper.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}
