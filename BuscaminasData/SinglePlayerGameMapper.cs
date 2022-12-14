using System.Collections.Generic;
using System.Data;

namespace BuscaminasData
{
    public class SinglePlayerGameMapper : GameMapper
    {
        public BuscaminasBE.SinglePlayerGame CreateNewGame(BuscaminasBE.SinglePlayerGame newGame)
        {
            if (newGame.UserId == -1)
            {
                // user is not logged in
                return null;
            }

            void action()
            {
                CreateBaseGame(newGame);

                IDictionary<string, object> createSinglePlayerParams = new Dictionary<string, object>();
                createSinglePlayerParams.Add("@id", newGame.Id);
                createSinglePlayerParams.Add("@userId", newGame.UserId);
                if (newGame.ResultId != -1)
                {
                    createSinglePlayerParams.Add("@resultId", newGame.ResultId);
                }
                database.ExecuteNonQuery("CREATE_SINGLE_P_GAME", createSinglePlayerParams);

                CreateBoardAndCells(newGame.Id, newGame.Board);
            }

            RunDatabaseOperation(action, true);

            return newGame;
        }

        public void SaveGame(BuscaminasBE.SinglePlayerGame game, BuscaminasBE.BoardCell lastCell)
        {
            if (game.UserId == -1)
            {
                return;
            }

            void action()
            {
                IDictionary<string, object> baseGameParams = new Dictionary<string, object>();
                baseGameParams.Add("@gameId", game.Id);
                baseGameParams.Add("@gameStateId", game.GameStateId);
                baseGameParams.Add("@timePlayed", game.TimePlayedInSeconds);
                database.ExecuteNonQuery("UPDATE_BASE_GAME", baseGameParams);

                IDictionary<string, object> singlePlayerGameParams = new Dictionary<string, object>();
                singlePlayerGameParams.Add("@id", game.Id);
                singlePlayerGameParams.Add("@resultId", game.ResultId);
                database.ExecuteNonQuery("UPDATE_SINGLE_PLAYER_GAME", singlePlayerGameParams);

                if (lastCell != null)
                {
                    MarkCellAsSelected(lastCell);
                }
            }

            RunDatabaseOperation(action, true);
        }
    
        public BuscaminasBE.SinglePlayerGame LoadGame(int gameId)
        {
            BuscaminasBE.SinglePlayerGame game = new BuscaminasBE.SinglePlayerGame();
            void loadGameAction()
            {
                BuscaminasBE.Board board = LoadBoardAndCells(gameId);

                IDictionary<string, object> loadSpgParams = new Dictionary<string, object>();
                loadSpgParams.Add("@gameId", gameId);
                DataTable spgTable = database.ReadDisconnected("LOAD_SINGLE_PLAYER_GAME", loadSpgParams);
                foreach(DataRow row in spgTable.Rows)
                {
                    game.Id = gameId;

                    string resultIdColumn = row["resultId"].ToString();
                    if (!string.IsNullOrEmpty(resultIdColumn))
                    {
                        game.ResultId = int.Parse(resultIdColumn);
                    }

                    game.UserId = int.Parse(row["userId"].ToString());
                    game.GameStateId = int.Parse(row["gameStateId"].ToString());
                    game.TimePlayedInSeconds = int.Parse(row["timePlayedInSeconds"].ToString());
                    game.Board = board;
                }
            }

            RunDatabaseOperation(loadGameAction, true);
            return game;
        }

        public List<BuscaminasBE.InProgressGame> LoadInProgressGames(int userId)
        {
            List<BuscaminasBE.InProgressGame> games = new List<BuscaminasBE.InProgressGame>();
            if (userId == -1)
            {
                return games;
            }
            void action()
            {
                IDictionary<string, object> loadSpgParams = new Dictionary<string , object>();
                loadSpgParams.Add("@userId", userId);
                DataTable table = database.ReadDisconnected("LOAD_INPROGRESS_SPG", loadSpgParams);
                foreach (DataRow row in table.Rows)
                {
                    BuscaminasBE.InProgressGame game = new BuscaminasBE.InProgressGame();
                    game.GameId = int.Parse(row["gameId"].ToString());
                    game.BoardWidth = int.Parse(row["boardWidth"].ToString());
                    game.BoardHeight = int.Parse(row["boardHeight"].ToString());
                    game.TotalMines = int.Parse(row["totalMines"].ToString());
                    game.RemaningMines = int.Parse(row["remainingMines"].ToString());

                    games.Add(game);
                }
            }
            RunDatabaseOperation(action);

            return games;
        }
    }
}
