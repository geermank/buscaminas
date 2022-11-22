namespace BuscaminasBE
{
    public class User
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private long lastLogin;

        public long LastLogin
        {
            get { return lastLogin; }
            set { lastLogin = value; }
        }

        public User()
        {
            id = -1;
        }
    }
}
