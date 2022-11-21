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
                return CountGamesByResult(GameResult.WIN);
            }
        }

        public int LostGamesCount
        {
            get
            {
                return CountGamesByResult(GameResult.LOST);
            }
        }

        public int TieGamesCount
        {
            get
            {
                return CountGamesByResult(GameResult.TIE);
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

        private int CountGamesByResult(GameResult expectedResult)
        {
            return (from BuscaminasBE.GameStatistics gs in gameStatistics
                    where (((GameResult)gs.SinglePlayerGameResult) == expectedResult) ||
                    (((GameResult)gs.MultiPlayerGameResult) == expectedResult)
                    select gs).Count();
        }
    }
}
