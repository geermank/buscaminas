using System.IO;

namespace BuscaminasAuth.Cached
{
    internal class CachedCredentials
    {
        private const string CACHED_CREDENTIALS_DIRECTORY = @"C:\Buscaminas";
        private const string CACHED_CREDENTIALS_FILE = @"C:\Buscaminas\users.txt";

        private CachedUserParser cachedUserParser;
        private CachedUserStrategy cachedUserStrategy;

        public CachedCredentials(CachedUserParser parser, CachedUserStrategy strategy)
        {
            cachedUserParser = parser;
            cachedUserStrategy = strategy;
        }

        public BuscaminasBE.User RestoreUser()
        {
            if (!File.Exists(CACHED_CREDENTIALS_FILE))
            {
                return null;
            }

            BuscaminasBE.User cachedUser;
            using (StreamReader stream = File.OpenText(CACHED_CREDENTIALS_FILE))
            {
                string userData = stream.ReadToEnd();
                cachedUser = cachedUserParser.Parse(userData);
            }

            if (cachedUser == null)
            {
                return null;
            }

            if (cachedUserStrategy.IsInvalidUser(cachedUser))
            {
                cachedUser = null;
                WipeCachedData();
            }

            return cachedUser;
        }

        public void SaveUser(BuscaminasBE.User user)
        {
            if (!Directory.Exists(CACHED_CREDENTIALS_DIRECTORY))
            {
                Directory.CreateDirectory(CACHED_CREDENTIALS_DIRECTORY);
            }
            if (!File.Exists(CACHED_CREDENTIALS_FILE))
            {
                File.Create(CACHED_CREDENTIALS_FILE).Close();
            }

            File.WriteAllText(CACHED_CREDENTIALS_FILE, cachedUserParser.Convert(user));
        }

        public void WipeCachedData()
        {
            File.Delete(CACHED_CREDENTIALS_FILE);
        }
    }
}
