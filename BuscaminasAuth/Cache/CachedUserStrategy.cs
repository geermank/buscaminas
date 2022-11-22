using System;

namespace BuscaminasAuth.Cached
{
    internal class CachedUserStrategy
    {
        private const int CACHED_USER_VALIDITY_IN_HOURS = 24;

        public bool IsInvalidUser(BuscaminasBE.User cachedUser)
        {
            var lastLogin = new DateTime(cachedUser.LastLogin);
            return (DateTime.Now - lastLogin).TotalHours > CACHED_USER_VALIDITY_IN_HOURS;
        }
    }
}
