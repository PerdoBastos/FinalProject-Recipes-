using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace AssemblyCookieRecipe.Repository.Implementation
{
    public class MeasureRepository : IMeasureRepository
    {
        private string _tableName = "Measures";
        public void DeleteById(int id)
        {
            string sql = $"DELETE FROM {_tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public List<Measure> GetAll()
        {
            List<Measure> measures = new List<Measure>();
            string sql = $"SELECT * FROM {_tableName};";
            SqlDataReader dataReader = SQL.ExecuteReader(sql);
            while (dataReader.Read())
            {
                Measure measure = Parse(dataReader);
                measures.Add(measure);
            }
            return measures;
        }

        public Measure GetById(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE id = {id};";
            SqlDataReader dataReader = SQL.ExecuteReader(sql);
            if (dataReader.Read())
            {
                return Parse(dataReader);
            }
            throw new Exception("Measure not found.");
        }

        public Measure Presist(Measure measure)
        {
            string sql = $"INSERT INTO {_tableName} (name) VALUES('{measure.Name}');";
            object result = SQL.ExecuteScalar(sql);
            if (result != null)
            {
                measure.Id = Convert.ToInt32(result);
            }

            return measure; //falta testar
        }

        public Measure Update(Measure measure)
        {
            string sql = $"UPDATE {_tableName} SET name = '{measure.Name}' WHERE id = {measure.Id};";
            SQL.ExecuteNonQuery(sql);
            return GetById(measure.Id);
        }

        private Measure Parse(SqlDataReader dataReader)
        {
            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(dataReader["id"]);
            measure.Name = Convert.ToString(dataReader["name"]);
            return measure;
        }
    }
}
