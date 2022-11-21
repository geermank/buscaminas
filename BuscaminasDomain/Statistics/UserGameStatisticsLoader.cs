using BuscaminasAuth;
using BuscaminasData;

namespace BuscaminasDomain.Statistics
{
    public class UserGameStatisticsLoader
    {
        private GameStatisticsMapper mapper = new GameStatisticsMapper();

        public UserGamesStatistics LoadUserStatistics()
        {
            int userId = Authentication.GetInstance().UserId;
            var gamesStatistics = mapper.LoadUserStatistics(userId);
            return new UserGamesStatistics(gamesStatistics);
        }
    }
}
