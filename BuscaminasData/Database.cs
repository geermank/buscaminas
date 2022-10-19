using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BuscaminasData
{
    public class Database
    {
        private SqlConnection connection;
        private string connectionString;

        private SqlTransaction transaction;

        public Database(string connectionString)
        {
            this.connectionString = connectionString;
            this.connection = new SqlConnection(connectionString);
        }

        public void ExecuteAsTransaction()
        {
            if (connection == null)
            {
                return;
            }
            transaction = connection.BeginTransaction();
        }

        public int ExecuteNonQuery(string sql, IDictionary<string, object> parameters)
        {
            connection.Open();

            SqlCommand command = new SqlCommand
            {
                CommandText = sql,
                CommandType = CommandType.Text,
                Connection = connection
            };
            if (transaction != null)
            {
                command.Transaction = transaction;
            }
            if (parameters != null)
            {
                foreach(KeyValuePair<string, object> param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            int result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }
    }
}
