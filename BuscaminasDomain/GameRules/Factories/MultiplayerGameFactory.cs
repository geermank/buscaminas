using BuscaminasDomain.GameBoard;
using System.Collections.Generic;

namespace BuscaminasDomain.GameRules.Factories
{
    public class MultiplayerGameFactory : IGameFactory
    {
        public Game CreateGame(GameDifficulty difficulty, Player player)
        {
            Board board = BoardGenerator.GetInstance().CreateBoard(difficulty);
            List<Player> players = new List<Player>() { player };
            return new MultiPlayerGame(board, players);
        }
    }
}
