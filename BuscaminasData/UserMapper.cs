using System;
using System.Collections.Generic;

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
                throw new Exception("El usuario ya está registrado!");
            }

            queryParams.Add("@name", user.Name);
            queryParams.Add("@password", user.Password);

            int createUserResult = database.ExecuteNonQuery("CREATE_USER", queryParams);
            if (createUserResult <= 0)
            {
                throw new Exception("No se pudo registrar el usuario");
            }

            database.CloseConnection();
        }
    }
}
