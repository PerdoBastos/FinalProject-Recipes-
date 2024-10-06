using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace AssemblyCookieRecipe.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private string _tableName = "Categories";
        public void DeleteById(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();
            string sql = $"SELECT * FROM {_tableName};";
            SqlDataReader dataReader = SQL.ExecuteReader(sql);
            while (dataReader.Read())
            {
                Category category = Parse(dataReader);
                categories.Add(category);
            }
            return categories;
        }

        public Category GetById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {id};";
            SqlDataReader dataReader = SQL.ExecuteReader(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            throw new Exception("Category not found.");
        }

        public Category Presist(Category category)
        {
            string sql = $"INSERT INTO {_tableName} (name) VALUES('{category.Name}');";
            object result = SQL.ExecuteScalar(sql);
            if (result != null)
            {
                category.Id = Convert.ToInt32(result);
            }

            return category; //falta testar
        }

        public Category Update(Category category)
        {
            string sql = $"UPDATE {_tableName} SET name = '{category.Name}' WHERE id = {category.Id};";
            SQL.ExecuteNonQuery(sql);
            return GetById(category.Id);
        }

        private Category Parse(SqlDataReader dataReader)
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(dataReader["id"]);
            category.Name = Convert.ToString(dataReader["name"]);
            return category;
        }
    }
}
