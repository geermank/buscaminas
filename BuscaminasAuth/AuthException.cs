using System;

namespace BuscaminasAuth
{
    public class AuthException : Exception 
    {
        public AuthException(string message) : base(message)
        {

        }
    }
}
