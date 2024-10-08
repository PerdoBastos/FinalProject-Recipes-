using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace AssemblyCookieRecipe.Repository.Implementation
{
    public class IngredientRepository : IIngredientRepository
    {
        private string _tableName = "Ingredients";
        public void DeleteById(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public List<Ingredient> GetAll()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string sql = $"SELECT * FROM {_tableName};";
            SqlDataReader dataReader = SQL.ExecuteReader(sql);
            while (dataReader.Read())
            {
                Ingredient ingredient = Parse(dataReader);
                ingredients.Add(ingredient);
            }
            return ingredients;
        }

        public Ingredient GetById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {id};";
            SqlDataReader dataReader = SQL.ExecuteReader(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            throw new Exception("Ingredient not found.");
        }

        public Ingredient Presist(Ingredient ingredient)
        {
            string sql = $"INSERT INTO {_tableName} (name) VALUES('{ingredient.Name}');";
            object result = SQL.ExecuteScalar(sql);
            if (result != null)
            {
                ingredient.Id = Convert.ToInt32(result);
            }

            return ingredient; //falta testar
        }

        public Ingredient Update(Ingredient ingredient)
        {
            string sql = $"UPDATE {_tableName} SET name = '{ingredient.Name}' WHERE id = {ingredient.Id};";
            SQL.ExecuteNonQuery(sql);
            return GetById(ingredient.Id);
        }
        private Ingredient Parse(SqlDataReader dataReader)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(dataReader["id"]);
            ingredient.Name = Convert.ToString(dataReader["name"]);
            return ingredient;
        }
    }
}
