namespace BuscaminasAuth
{
    internal class Password
    {
        private const int PASSWORD_MIN_LENGTH = 7;

        private readonly string value;

        public string Value
        {
            get { return value; }
        }

        public Password(string value)
        {
            this.value = value;
        }

        public void Validate()
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new AuthException("La constraseña no puede estar vacía");
            }
            if (value.Length < PASSWORD_MIN_LENGTH)
            {
                throw new AuthException("La constraseña debe tener al menos 7 caracteres");
            }
        }
    }
}
