using System;

namespace BuscaminasData
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {

        }
    }
}
