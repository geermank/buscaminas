using BuscaminasAuth;
using BuscaminasDomain.GameRules.Result;
using System.Collections.Generic;
using System.Linq;

namespace BuscaminasDomain.Statistics
{
    public class UserGamesStatistics
    {

        private List<BuscaminasBE.GameStatistics> gameStatistics;

        public List<BuscaminasBE.GameStatistics> GameStatistics
        {
            get { return gameStatistics; }
        }

        public UserGamesStatistics(List<BuscaminasBE.GameStatistics> gameStatistics)
        {
            this.gameStatistics = gameStatistics;
        }

        public int WonGamesCount
        {
            get
            {
                var currentUserId = Authentication.GetInstance().UserId;
                return (from BuscaminasBE.GameStatistics gs in gameStatistics
                        where (((GameResult)gs.SinglePlayerGameResult) == GameResult.WIN) ||
                        ((((GameResult)gs.MultiPlayerGameResult) == GameResult.WIN) && gs.Winner == currentUserId)
                        select gs).Count();
            }
        }

        public int LostGamesCount
        {
            get
            {
                var currentUserId = Authentication.GetInstance().UserId;
                return (from BuscaminasBE.GameStatistics gs in gameStatistics
                        where (((GameResult)gs.SinglePlayerGameResult) == GameResult.WIN) ||
                        ((((GameResult)gs.MultiPlayerGameResult) == GameResult.WIN) && gs.Winner != currentUserId)
                        select gs).Count();
            }
        }

        public int TieGamesCount
        {
            get
            {
                return (from BuscaminasBE.GameStatistics gs in gameStatistics
                        where (((GameResult)gs.SinglePlayerGameResult) == GameResult.TIE) ||
                        (((GameResult)gs.MultiPlayerGameResult) == GameResult.TIE)
                        select gs).Count();
            }
        }

        public int TotalTimePlayedInSeconds
        {
            get
            {
                return (from BuscaminasBE.GameStatistics gs in gameStatistics
                        select gs.TimePlayed).Sum();
            }
        }

        public float WinRate
        {
            get
            {
                float winRate = 0;
                if (gameStatistics.Count > 0)
                {
                    winRate = (WonGamesCount / (float) gameStatistics.Count) * 100;
                }
                return winRate;
            }
        }
    }
}
