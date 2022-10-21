using System.Text.RegularExpressions;

namespace BuscaminasAuth
{
    internal class UserEmail
    {
        private const string EMAIL_REGEX = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        private string value;

        public string Value
        {
            get { return value; }
        }

        public UserEmail(string value)
        {
            this.value = value;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new AuthException("El correo no puede estar vacío");
            }

            Regex reguex = new Regex(EMAIL_REGEX);
            if (!reguex.Match(value).Success)
            {
                throw new AuthException("Ingresá un correo válido");
            }
        }
    }
}
