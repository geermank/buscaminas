using BuscaminasAuth.Cached;
using BuscaminasData;
using System;

namespace BuscaminasAuth.AuthMethod
{
    internal class EmailPasswordAuthMethod
    {
        private readonly UserMapper userMapper = new UserMapper();

        private readonly CachedCredentials userCache;

        public EmailPasswordAuthMethod()
        {
            userCache = new CachedCredentials(new CachedUserParser(), new CachedUserStrategy());
        }

        public BuscaminasBE.User GetLoggedUser()
        {
            return userCache.RestoreUser();
        }

        public BuscaminasBE.User CreateUser(string username, string email, string password)
        {
            var userName = new UserName(username);
            userName.Validate();

            var userEmail = new Email(email);
            userEmail.Validate();

            var userPass = new Password(password);
            userPass.Validate();

            BuscaminasBE.User user = new BuscaminasBE.User();
            user.Email = userEmail.Value;
            user.Name = userName.Value;
            user.Password = userPass.Value;
            user.LastLogin = DateTime.Now.Ticks;

            try
            {
                userMapper.CreateUser(user);
                userCache.SaveUser(user);
            }
            catch (DatabaseException ex)
            {
                throw new AuthException(ex.Message);
            }

            return user;
        }

        public BuscaminasBE.User Login(string email, string password)
        {
            var userEmail = new Email(email);
            userEmail.Validate();

            var userPass = new Password(password);
            userPass.Validate();

            BuscaminasBE.User user;
            try
            {
                user = userMapper.Login(email, password);
                userCache.SaveUser(user);
            }
            catch (DatabaseException ex)
            {
                throw new AuthException(ex.Message);
            }

            return user;
        }

        public void Logout()
        {
            userCache.WipeCachedData();
        }
    }
}
