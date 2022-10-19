using BuscaminasDomain.GameBoard;

namespace BuscaminasDomain.GameRules.Factories
{
    public class SinglePlayerGameFactory : IGameFactory
    {
        public Game CreateGame(GameDifficulty difficulty, Player player)
        {
            Board board = BoardGenerator.GetInstance().CreateBoard(difficulty);
            return new SinglePlayerGame(board, player);
        }
    }
}
