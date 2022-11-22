namespace BuscaminasAuth
{
    internal class UserName
    {
        private readonly string value;

        public string Value
        {
            get { return value; }
        }

        public UserName(string value)
        {
            this.value = value;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new AuthException("El nombre de usuario no puede estar vacío");
            }
        }
    }
}
