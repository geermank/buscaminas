using BuscaminasAuth.AuthMethod;
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

        private EmailPasswordAuthMethod authMethod;

        private BuscaminasBE.User currentUser = null;

        public bool UserLogged
        {
            get { return currentUser != null; }
        }

        public string UserName
        {
            get { return currentUser.Name; }
        }

        public int UserId {
            get {
                if (currentUser == null)
                {
                    return -1;
                } else
                {
                    return currentUser.Id;
                }
            }
        }

        public BuscaminasBE.User CurrentUser
        {
            get { return currentUser; }
        }

        private Authentication()
        {
            this.authMethod = new EmailPasswordAuthMethod();
            this.currentUser = authMethod.GetLoggedUser();
        }

        public void CreateUser(string name, string email, string password)
        {
            currentUser = authMethod.CreateUser(name, email, password);
            Analytics.GetInstance().Log(Event.USER_CREATED);
        }

        public void Login(string email, string password)
        {
            currentUser = authMethod.Login(email, password);
            Analytics.GetInstance().Log(Event.LOGIN);
        }

        public void Logout()
        {
            authMethod.Logout();
            currentUser = null;
            Analytics.GetInstance().Log(Event.LOGOUT);
        }
    }
}
