using BuscaminasAuth;
using BuscaminasDomain.GameBoard;

namespace BuscaminasDomain.GameRules.Factories
{
    public class SinglePlayerGameFactory : IGameFactory
    {
        public Game CreateGame(GameDifficulty difficulty)
        {
            Board board = BoardGenerator.GetInstance().CreateBoard(difficulty);
            return new SinglePlayerGame(board, GetPlayerId());
        }

        private int GetPlayerId()
        {
            Authentication auht = Authentication.GetInstance();

            int playerId;
            if (auht.UserLogged)
            {
                playerId = auht.UserId;
            } else
            {
                playerId = -1;
            }
            return playerId;
        }
    }
}
