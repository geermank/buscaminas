using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BuscaminasData
{
    public class SqlDatabase
    {
        private string connectionString;

        private SqlConnection sqlConnection;
        private SqlTransaction sqlTransaction;

        public SqlDatabase(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public void OpenConnection()
        {
            if (sqlConnection != null)
            {
                return;
            }
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        public void CloseConnection()
        {
            sqlConnection.Close();
            sqlConnection = null;
        }

        public void RunTransaction()
        {
            if (sqlConnection == null || sqlTransaction != null)
            {
                return;
            }
            sqlTransaction = sqlConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            sqlTransaction.Commit();
            DisposeTransaction();
        }

        public void RollbackTransaction()
        {
            sqlTransaction.Rollback();
            DisposeTransaction();
        }

        public int ExecuteNonQuery(string sql, IDictionary<string, object> parameters = null)
        {
            SqlCommand command = CreateCommand(sql, parameters);
            int result = command.ExecuteNonQuery();
            return result;
        }

        public int ExecuteScalar(string sql, IDictionary<string, object> parameters = null)
        {
            SqlCommand cmd = CreateCommand(sql, parameters);
            int result = int.Parse(cmd.ExecuteScalar().ToString());
            return result;
        }

        public DataTable ReadDisconnected(string sql, IDictionary<string, object> parameters = null)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = CreateCommand(sql, parameters);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        private void DisposeTransaction()
        {
            sqlTransaction.Dispose();
            sqlTransaction = null;
        }

        private SqlCommand CreateCommand(string sql, IDictionary<string, object> parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
            }
            if (sqlTransaction != null)
            {
                cmd.Transaction = sqlTransaction;
            }
            return cmd;
        }
    }
}
