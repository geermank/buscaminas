using System;
using System.Collections.Generic;
using System.Data;

namespace BuscaminasData
{
    public class MultiPlayerGameMapper : GameMapper
    {
        public BuscaminasBE.MultiplayerGame CreateGame(int userId, BuscaminasBE.MultiplayerGame newGame)
        {
            void action()
            {
                CreateBaseGame(newGame);

                IDictionary<string, object> mpgParams = new Dictionary<string, object>();
                mpgParams.Add("@gameId", newGame.Id);
                mpgParams.Add("@ownerId", userId);
                database.ExecuteNonQuery("CREATE_MULTIPLAYER_GAME", mpgParams);

                CreateBoardAndCells(newGame.Id, newGame.Board);
            }

            RunDatabaseOperation(action, true);

            return newGame;
        }

        public void UpdateTurn(int turnId, BuscaminasBE.Turn turn)
        {
            void action()
            {
                IDictionary<string, object> updateTurnParams = new Dictionary<string, object>();
                updateTurnParams.Add("@turnId", turnId);
                updateTurnParams.Add("@currentPlayerId", turn.CurrentPlayerId);
                updateTurnParams.Add("@turnNumber", turn.Number);
                database.ExecuteNonQuery("UPDATE_TURN", updateTurnParams);
            }

            RunDatabaseOperation(action);
        }

        public void UpdatePlayerScore(int gameId, int? userId, int? score)
        {
            if (userId == null)
            {
                return;
            }
            void action()
            {
                IDictionary<string, object> scoreParams = new Dictionary<string, object>();
                scoreParams.Add("@userId", userId);
                scoreParams.Add("@gameId", gameId);
                scoreParams.Add("@score", score);
                database.ExecuteNonQuery("UPDATE_PLAYER_SCORE", scoreParams);
            }
            RunDatabaseOperation(action);
        }

        public List<BuscaminasBE.InProgressGame> LoadOpenRooms(int currentUserId)
        {
            List<BuscaminasBE.InProgressGame> games = new List<BuscaminasBE.InProgressGame>();

            void action()
            {
                IDictionary<string, object> queryParams = new Dictionary<string , object>();
                queryParams.Add("@userId", currentUserId);
                DataTable rooms = database.ReadDisconnected("LOAD_OPEN_ROOMS", queryParams);
                foreach(DataRow row in rooms.Rows)
                {
                    BuscaminasBE.InProgressGame game = new BuscaminasBE.InProgressGame();
                    game.GameId = int.Parse(row["gameId"].ToString());
                    game.BoardHeight = int.Parse(row["boardHeight"].ToString());
                    game.BoardWidth = int.Parse(row["boardWidth"].ToString());
                    game.RemaningMines = int.Parse(row["remainingMines"].ToString());
                    game.TotalMines = int.Parse(row["totalMines"].ToString());
                    games.Add(game);
                }
            }

            RunDatabaseOperation(action);

            return games;
        }

        public List<BuscaminasBE.InProgressGame> LoadInProgressGames(int userId)
        {
            List<BuscaminasBE.InProgressGame> games = new List<BuscaminasBE.InProgressGame>();
            void action()
            {
                IDictionary<string, object> queryParams = new Dictionary<string, object>();
                queryParams.Add("@userId", userId);
                DataTable rooms = database.ReadDisconnected("LOAD_MPG_IN_PROGRESS", queryParams);
                foreach (DataRow row in rooms.Rows)
                {
                    BuscaminasBE.InProgressGame game = new BuscaminasBE.InProgressGame();
                    game.GameId = int.Parse(row["gameId"].ToString());
                    game.BoardHeight = int.Parse(row["boardHeight"].ToString());
                    game.BoardWidth = int.Parse(row["boardWidth"].ToString());
                    game.RemaningMines = int.Parse(row["remainingMines"].ToString());
                    game.TotalMines = int.Parse(row["totalMines"].ToString());
                    game.GameOwnerName = row["gameOwnerName"].ToString();
                    games.Add(game);
                }
            }

            RunDatabaseOperation(action);

            return games;
        }

        public BuscaminasBE.MultiplayerGame JoinGame(int gameId, int userId)
        {
            BuscaminasBE.MultiplayerGame game = null;

            void action() {
                IDictionary<string, object> getPlayersCountParams = new Dictionary<string, object>();
                getPlayersCountParams.Add("@gameId", gameId);
                int playersCount = database.ExecuteScalar("GET_PLAYERS_COUNT", getPlayersCountParams);

                if (playersCount >= 2)
                {
                    throw new DatabaseException("Este juego está completo");
                }

                IDictionary<string, object> joinRoomParams = new Dictionary<string, object>();
                joinRoomParams.Add("@userId", userId);
                joinRoomParams.Add("@gameId", gameId);
                database.ExecuteNonQuery("JOIN_PLAYER_INTO_ROOM", joinRoomParams);

                game = LoadGame(gameId);
            }

            RunDatabaseOperation(action, true);

            return game;
        }

        public BuscaminasBE.MultiplayerGame LoadMultiplayerGame(int gameId)
        {
            BuscaminasBE.MultiplayerGame game = null;
            void action()
            {
                game = LoadGame(gameId);
            }

            RunDatabaseOperation(action);

            return game;
        }

        private BuscaminasBE.MultiplayerGame LoadGame(int gameId)
        {
            BuscaminasBE.MultiplayerGame game = new BuscaminasBE.MultiplayerGame();
            game.Id = gameId;
            game.Board = LoadBoardAndCells(gameId);

            IDictionary<string, object> mpgParams = new Dictionary<string, object>();
            mpgParams.Add("@gameId", gameId);
            DataTable table = database.ReadDisconnected("LOAD_MULTIPLAYER_GAME", mpgParams);
            foreach(DataRow row in table.Rows)
            {
                game.GameStateId = int.Parse(row["gameStateId"].ToString());
                game.TimePlayedInSeconds = int.Parse(row["timePlayedInSeconds"].ToString());

                BuscaminasBE.Turn turn = new BuscaminasBE.Turn();
                turn.Number = int.Parse(row["number"].ToString());
                string currentPlayerId = row["currentPlayerId"].ToString();
                if (!string.IsNullOrEmpty(currentPlayerId))
                {
                    turn.CurrentPlayerId = int.Parse(currentPlayerId);
                }
            }

            return game;
        }

    }
}
