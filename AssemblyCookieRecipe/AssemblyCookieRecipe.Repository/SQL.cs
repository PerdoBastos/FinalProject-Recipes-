using Microsoft.Data.SqlClient;

namespace AssemblyCookieRecipe.Repository
{
    public class SQL
    {
        private static readonly string _connectionString = $"Data Source=LAPTOP-LHL35TFV\\SQLEXPRESS;Database=AssemblyCookieRecipe;Integrated Security=True;TrustServerCertificate=True;";
        private static readonly SqlConnection sqlConnection = new SqlConnection(_connectionString);

        internal static int ExecuteNonQuery(string sql)
        {
            isConnectionOpen();

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            int affectedRows = sqlCommand.ExecuteNonQuery();
            return affectedRows;
        }

        internal static object ExecuteScalar(string sql)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                object result = sqlCommand.ExecuteScalar();
                return result;
            }
        }

        internal static SqlDataReader ExecuteReader(string sql)
        {
            isConnectionOpen();
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            return sqlDataReader;
        }

        private static void isConnectionOpen()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
    }
}
