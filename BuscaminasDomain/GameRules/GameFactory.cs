using BuscaminasDomain.GameBoard;
using System.Collections.Generic;

namespace BuscaminasDomain.GameRules
{
    public class GameFactory
    {
        private BoardGenerator boardGenerator = new BoardGenerator();

        private static GameFactory gameFactory;

        public static GameFactory GetInstance()
        {
            if (gameFactory == null)
            {
                gameFactory = new GameFactory();
            }
            return gameFactory;
        }

        private GameFactory()
        {
            // private default constructor
        }

        public Game NewSinglePlayerGame(GameDifficulty difficulty, Player player)
        {
            Board board = boardGenerator.CreateBoard(difficulty);
            return new SinglePlayerGame(board, player);
        }

        public Game NewMultiplayerGame(GameDifficulty difficulty, List<Player> players)
        {
            Board board = boardGenerator.CreateBoard(difficulty);
            return new MultiPlayerGame(board, players);
        }

        public Game NewMultiplayerGame(GameDifficulty difficulty, Player owner)
        {
            Board board = boardGenerator.CreateBoard(difficulty);
            List<Player> players = new List<Player>() { owner };
            return new MultiPlayerGame(board, players);
        }
    }
}
