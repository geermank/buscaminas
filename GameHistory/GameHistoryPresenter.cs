using BuscaminasDomain.Statistics;
using BuscaminasDomain.GameRules.Result;
using System.Collections.Generic;
using BuscaminasAuth;

namespace Buscaminas.GameHistory
{
    internal class GameHistoryPresenter 
    {
        internal interface IGameHistoryForm
        {
            void ShowGamesWonCount(string labelValue);
            void ShowGamesTieCount(string labelValue);
            void ShowGamesLostCount(string labelValue);
            void ShowWinRate(string labelValue);
            void ShowTotalTimePlayed(string labelValue);
            void ShowGamesHistory(List<GameHistoryItem> games);
        }

        private const int ONE_MINUTE_IN_SECONDS = 60;
        private const int ONE_HOUR_IN_SECONDS = ONE_MINUTE_IN_SECONDS * 60;

        private IGameHistoryForm form;

        private UserGameStatisticsLoader statisticsLoader;

        public GameHistoryPresenter(IGameHistoryForm form)
        {
            this.form = form;
            this.statisticsLoader = new UserGameStatisticsLoader();
        }

        public void OnFormStarted()
        {
            var statistics = statisticsLoader.LoadUserStatistics();
            form.ShowGamesWonCount("Partidas ganadas: " + statistics.WonGamesCount);
            form.ShowGamesTieCount("Partidas empatadas: " + statistics.TieGamesCount);
            form.ShowGamesLostCount("Partidas perdidas: " + statistics.LostGamesCount);
            form.ShowWinRate(statistics.WinRate.ToString("0.00") + "%");
            form.ShowTotalTimePlayed(FormatTimePlayed(statistics.TotalTimePlayedInSeconds));

            List<GameHistoryItem> gameHistoryItems = new List<GameHistoryItem>();
            foreach(BuscaminasBE.GameStatistics s in statistics.GameStatistics)
            {
                gameHistoryItems.Add(MapToGameHistoryItem(s));
            }
            form.ShowGamesHistory(gameHistoryItems);
        }

        private string FormatTimePlayed(int totalTimePlayedInSeconds)
        {
            string labelValue;
            if (totalTimePlayedInSeconds > 0 && totalTimePlayedInSeconds < 60)
            {
                labelValue = totalTimePlayedInSeconds + " segundos";
            } else if (totalTimePlayedInSeconds >= 60 && totalTimePlayedInSeconds < ONE_HOUR_IN_SECONDS)
            {
                labelValue = (totalTimePlayedInSeconds / 60) + " minutos";
            } else
            {
                labelValue = (totalTimePlayedInSeconds / 60) / 60 + " horas";
            }
            return labelValue;
        }

        private GameHistoryItem MapToGameHistoryItem(BuscaminasBE.GameStatistics gameStatistics)
        {
            GameHistoryItem gameHistoryItem = new GameHistoryItem();
            gameHistoryItem.GameId = gameStatistics.Id;

            string gameType = "";
            string gameResult = "";
            if (gameStatistics.SinglePlayerGameResult == -1)
            {
                gameType = "Multiplayer";
                GameResult result = (GameResult) gameStatistics.MultiPlayerGameResult;
                gameResult = GetUiResult(result, true, gameStatistics.Winner);

            } else if (gameStatistics.MultiPlayerGameResult == -1)
            {
                gameType = "Single player";
                GameResult result = (GameResult)gameStatistics.SinglePlayerGameResult;
                gameResult = GetUiResult(result, false, null);
            }

            gameHistoryItem.Title = gameType + " - " + gameResult + " - " + gameStatistics.BoardWidth + "x" + gameStatistics.BoardHeight;

            return gameHistoryItem;
        }

        private string GetUiResult(GameResult result, bool isMultiplayer, int? multiplayerWinner)
        {
            string gameResult = "";
            if (result == GameResult.TIE)
            {
                gameResult = "Empate";
            }
            else if (result == GameResult.LOST)
            {
                gameResult = "Perdido";
            }
            else if (result == GameResult.WIN)
            {
                gameResult = "Ganado";
                if (isMultiplayer)
                {
                    var currentUserId = Authentication.GetInstance().UserId;
                    if (multiplayerWinner != null && multiplayerWinner != currentUserId)
                    {
                        gameResult = "Perdido";
                    }
                }
            }
            return gameResult;
        }
    }

    public class GameHistoryItem
    {
        private int gameId;

        public int GameId
        {
            get { return gameId; }
            set { gameId = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public override string ToString()
        {
            return title;
        }
    }
}
