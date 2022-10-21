using BuscaminasData;
using System;

namespace BuscaminasAuth
{
    public class Authentication
    {
        private static Authentication _instance;

        public static Authentication GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Authentication();
            }
            return _instance;
        }

        public void CreateUser(string name, string email, string password)
        {
            var userName = new UserName(name);
            userName.Validate();

            var userEmail = new UserEmail(email);
            userEmail.Validate();

            var userPass = new Password(password);
            userPass.Validate();

            BuscaminasBE.User user = new BuscaminasBE.User();
            user.Email = userEmail.Value;
            user.Name = userName.Value;
            user.Password = userPass.Value;

            try
            {
                UserMapper userMapper = new UserMapper();
                userMapper.CreateUser(user);
            } catch(Exception ex)
            {
                throw new AuthException(ex.Message);
            }
        }

        public void Login(string email, string password)
        {
            var userEmail = new UserEmail(email);
            userEmail.Validate();

            var userPass = new Password(password);
            userPass.Validate();


        }


        public bool IsUserLogged()
        {
            return false;
        }
    }
}
