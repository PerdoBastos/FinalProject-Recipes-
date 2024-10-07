using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace AssemblyCookieRecipe.Repository.Implementation
{
    public class DifficultieRepository : IDifficultieRepository
    {
        private string _tableName = "Difficulties";
        public void DeleteById(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public List<Difficultie> GetAll()
        {
            List<Difficultie> difficulties = new List<Difficultie>();
            string sql = $"SELECT * FROM {_tableName};";
            SqlDataReader dataReader = SQL.ExecuteReader(sql);
            while (dataReader.Read())
            {
                Difficultie difficultie = Parse(dataReader);
                difficulties.Add(difficultie);
            }
            return difficulties;
        }

        public Difficultie GetById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {id};";
            SqlDataReader dataReader = SQL.ExecuteReader(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            throw new Exception("Difficultie not found.");
        }

        public Difficultie Presist(Difficultie difficultie)
        {
            string sql = $"INSERT INTO {_tableName} (name) VALUES('{difficultie.Name}');";
            object result = SQL.ExecuteScalar(sql);
            if (result != null)
            {
                difficultie.Id = Convert.ToInt32(result);
            }

            return difficultie; //falta testar
        }

        public Difficultie Update(Difficultie difficultie)
        {
            string sql = $"UPDATE {_tableName} SET name = '{difficultie.Name}' WHERE id = {difficultie.Id};";
            SQL.ExecuteNonQuery(sql);
            return GetById(difficultie.Id);
        }

        private Difficultie Parse(SqlDataReader dataReader)
        {
            Difficultie difficultie = new Difficultie();
            difficultie.Id = Convert.ToInt32(dataReader["id"]);
            difficultie.Name = Convert.ToString(dataReader["name"]);
            return difficultie;
        }
    }
}
