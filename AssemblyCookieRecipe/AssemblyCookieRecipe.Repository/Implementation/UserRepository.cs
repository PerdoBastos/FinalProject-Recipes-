using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace AssemblyCookieRecipe.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private string _tableName = "Users";
        public void DeleteById(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            string sql = $"SELECT * FROM {_tableName};";
            SqlDataReader dataReader = SQL.ExecuteReader(sql);
            while (dataReader.Read())
            {
                User user = Parse(dataReader);
                users.Add(user);
            }
            return users;
        }

        public User GetById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {id};";
            SqlDataReader dataReader = SQL.ExecuteReader(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            throw new Exception("Category not found.");
        }

        public User Presist(User user)
        {
            int isAdmin;
            int isBlocked;

            if (user.IsAdmin)
            {
                isAdmin = 1;
            }
            else
            {
                isAdmin = 0;
            }

            if (user.IsBlocked)
            {
                isBlocked = 1;
            }
            else
            {
                isBlocked = 0;
            }

            string sql = $"INSERT INTO {_tableName} (username, password, name, email, isadmin, isblocked) VALUES('{user.Username}','{user.Password}','{user.Name}','{user.Email}','{isAdmin}','{isBlocked}');";
            object result = SQL.ExecuteScalar(sql);
            if (result != null)
            {
                user.Id = Convert.ToInt32(result);
            }

            return user;
        }

        public User Update(User user)
        {
            string sql = $"UPDATE {_tableName} SET username='{user.Username}', password='{user.Password}', name = '{user.Name}', email='{user.Email}', isadmin='{user.IsAdmin}', isblocked='{user.IsBlocked}'  WHERE id = {user.Id};";
            SQL.ExecuteNonQuery(sql);
            return GetById(user.Id);
        }
        private User Parse(SqlDataReader dataReader)
        {
            User user = new User();
            user.Id = Convert.ToInt32(dataReader["id"]);
            user.Username = Convert.ToString(dataReader["username"]);
            user.Password = Convert.ToString(dataReader["password"]);
            user.Name = Convert.ToString(dataReader["name"]);
            user.Email = Convert.ToString(dataReader["email"]);
            user.IsAdmin = Convert.ToBoolean(dataReader["isadmin"]);
            user.IsBlocked = Convert.ToBoolean(dataReader["isblocked"]);
            return user;
        }
    }
}
