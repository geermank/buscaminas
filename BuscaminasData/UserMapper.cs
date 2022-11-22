using System;
using System.Collections.Generic;
using System.Data;

namespace BuscaminasData
{
    public class UserMapper : BaseMapper
    {

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
            queryParams.Add("@lastLoging", user.LastLogin);

            int userId = database.ExecuteNonQueryWithReturnValue("CREATE_USER", queryParams);
            user.Id = userId;

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
                user.LastLogin = DateTime.Now.Ticks;
            }

            if (user.Id == -1)
            {
                // no se encontró el usuario
                throw new DatabaseException("El usuario no se encuentra registrado");
            } else
            {
                database.OpenConnection();

                IDictionary<string, object> lastLoginParams = new Dictionary<string, object>();
                lastLoginParams.Add("@userId", user.Id);
                lastLoginParams.Add("@lastLogin", user.LastLogin);

                database.ExecuteNonQuery("UPDATE_LAST_LOGIN", lastLoginParams);
                
                database.CloseConnection();
            }

            return user;
        }
    }
}
