using BuscaminasAuth;
using BuscaminasDomain.GameBoard;
using System.Collections.Generic;

namespace BuscaminasDomain.GameRules.Factories
{
    public class MultiplayerGameFactory : IGameFactory
    {
        public Game CreateGame(GameDifficulty difficulty)
        {
            Board board = BoardGenerator.GetInstance().CreateBoard(difficulty);

            Player player = new Player(Authentication.GetInstance().CurrentUser);
            List<Player> players = new List<Player>() { player };

            return new MultiPlayerGame(board, players);
        }
    }
}
