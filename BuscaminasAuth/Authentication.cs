using BuscaminasData;

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

        private BuscaminasBE.User currentUser = null;

        private UserMapper userMapper;

        public bool UserLogged
        {
            get { return currentUser != null; }
        }

        public string UserName
        {
            get { return currentUser.Name; }
        }

        private Authentication()
        {
            userMapper = new UserMapper();
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
                userMapper.CreateUser(user);
                currentUser = user;
            } catch(DatabaseException ex)
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

            try
            {
                currentUser = userMapper.Login(email, password);
            } catch(DatabaseException ex)
            {
                throw new AuthException(ex.Message);
            }
        }
    }
}
