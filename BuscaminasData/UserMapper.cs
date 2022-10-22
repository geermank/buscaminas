using System;
using System.Collections.Generic;
using System.Data;

namespace BuscaminasData
{
    public class UserMapper
    {
        private SqlDatabase database;

        public UserMapper()
        {
            database = new SqlDatabase(Constants.CONNECTION_STRING);
        }

        public void CreateUser(BuscaminasBE.User user)
        {
            database.OpenConnection();

            IDictionary<string, object> queryParams = new Dictionary<string, object>();
            queryParams.Add("@email", user.Email);
            
            int userExistsResult = database.ExecuteScalar("CHECK_USER_EXISTS", queryParams);
            if(userExistsResult > 0)
            {
                database.CloseConnection();
                throw new DatabaseException("El usuario ya está registrado!");
            }

            queryParams.Add("@name", user.Name);
            queryParams.Add("@password", user.Password);

            int createUserResult = database.ExecuteNonQuery("CREATE_USER", queryParams);
            if (createUserResult <= 0)
            {
                throw new DatabaseException("No se pudo registrar el usuario");
            }

            database.CloseConnection();
        }

        public BuscaminasBE.User Login(string email, string password)
        {
            database.OpenConnection();

            IDictionary<string, object> queryParams = new Dictionary<string, object>();
            queryParams.Add("@email", email);
            queryParams.Add("@password", password);

            DataTable table = database.ReadDisconnected("GET_USER", queryParams);

            database.CloseConnection();

            BuscaminasBE.User user = new BuscaminasBE.User();

            foreach (DataRow row in table.Rows)
            {
                user.Id = int.Parse(row["id"].ToString());
                user.Name = row["name"].ToString();
                user.Email = row["email"].ToString();
                user.Password = row["password"].ToString();
            }

            if (user.Id == -1)
            {
                // no se encontró el usuario
                throw new DatabaseException("El usuario no se encuentra registrado");
            }

            return user;
        }
    }
}
