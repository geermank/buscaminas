using System.Collections.Generic;
using System.Data;

namespace BuscaminasData
{
    public class GameStatisticsMapper : BaseMapper
    {

        public List<BuscaminasBE.GameStatistics> LoadUserStatistics(int userId)
        {
            List<BuscaminasBE.GameStatistics> statistics = new List<BuscaminasBE.GameStatistics>();

            void action()
            {
                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@userId", userId);

                DataTable table = database.ReadDisconnected("GET_GAMES_STATISTICS", parameters);
                foreach(DataRow row in table.Rows)
                {
                    BuscaminasBE.GameStatistics gs = new BuscaminasBE.GameStatistics();
                    gs.Id = int.Parse(row["id"].ToString());

                    string singlePlayerResult = row["singlePlayerResult"].ToString();
                    if (!string.IsNullOrEmpty(singlePlayerResult))
                    {
                        gs.SinglePlayerGameResult = int.Parse(singlePlayerResult);
                    } else
                    {
                        gs.SinglePlayerGameResult = -1;
                    }

                    string multiPlayerResult = row["multiPlayerResult"].ToString();
                    if (!string.IsNullOrEmpty(multiPlayerResult))
                    {
                        gs.MultiPlayerGameResult = int.Parse(multiPlayerResult);
                    }
                    else
                    {
                        gs.MultiPlayerGameResult = -1;
                    }

                    
                    gs.BoardHeight = int.Parse(row["boardHeight"].ToString());
                    gs.BoardWidth = int.Parse(row["boardWidth"].ToString());
                    gs.NumberOfMines = int.Parse(row["numberOfMines"].ToString());
                    gs.TimePlayed = int.Parse(row["timePlayed"].ToString());

                    statistics.Add(gs);
                }
            }

            RunDatabaseOperation(action);

            return statistics;
        }
    }
}
