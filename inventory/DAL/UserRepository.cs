using System;
using System.Data;
using System.Data.SQLite;
using inventory.Models;
using inventory.Helpers;

namespace inventory.DAL
{
    public class UserRepository
    {
        public User Login(string username, string password)
        {
            string sql = "SELECT * FROM Users WHERE Username = @user AND Password = @pass";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@user", username),
                new SQLiteParameter("@pass", password)
            };

            DataTable dt = DbHelper.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new User {
                    Id = Convert.ToInt32(row["Id"]),
                    Username = row["Username"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Role = row["Role"].ToString()
                };
            }
            return null;
        }

        public bool Register(User user)
        {
            string sql = "INSERT INTO Users (Username, Password, FullName, Role) VALUES (@user, @pass, @name, @role)";
            SQLiteParameter[] parameters = {
                new SQLiteParameter("@user", user.Username),
                new SQLiteParameter("@pass", user.Password),
                new SQLiteParameter("@name", user.FullName),
                new SQLiteParameter("@role", user.Role)
            };
            return DbHelper.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}
