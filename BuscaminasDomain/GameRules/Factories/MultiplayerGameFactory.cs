using BuscaminasAuth;
using BuscaminasData;
using BuscaminasDomain.GameBoard;
using System.Collections.Generic;

namespace BuscaminasDomain.GameRules.Factories
{
    public class MultiplayerGameFactory : IGameFactory
    {
        private MultiPlayerGameMapper mapper = new MultiPlayerGameMapper();

        public virtual Game CreateGame(GameDifficulty difficulty)
        {
            Board board = BoardGenerator.GetInstance().CreateBoard(difficulty);

            Player player = new Player(Authentication.GetInstance().CurrentUser);
            List<Player> players = new List<Player>() { player };
            MultiPlayerGame newGame = new MultiPlayerGame(board, players);

            var gameData = mapper.CreateGame(Authentication.GetInstance().UserId, newGame.ToBEObject());
            newGame.UpdateIds(gameData);

            return newGame;
        }
    }
}
