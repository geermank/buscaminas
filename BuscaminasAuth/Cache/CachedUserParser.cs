using System.Text;

namespace BuscaminasAuth.Cached
{
    internal class CachedUserParser
    {

        public BuscaminasBE.User Parse(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            var splitData = data.Split(',');

            var user = new BuscaminasBE.User();
            user.Id = int.Parse(splitData[0]);
            user.Name = splitData[1];
            user.Email = splitData[2];
            user.Password = splitData[3];
            user.LastLogin = long.Parse(splitData[4]);

            return user;
        }

        public string Convert(BuscaminasBE.User user)
        {
            if (user == null)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(user.Id);
            sb.Append(",");
            sb.Append(user.Name);
            sb.Append(",");
            sb.Append(user.Email);
            sb.Append(",");
            sb.Append(user.Password);
            sb.Append(",");
            sb.Append(user.LastLogin);
            return sb.ToString();
        }
    }
}
