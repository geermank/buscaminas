using BuscaminasAuth;
using BuscaminasData;
using BuscaminasDomain.GameBoard;

namespace BuscaminasDomain.GameRules.Factories
{
    public class SinglePlayerGameFactory : IGameFactory
    {
        private SinglePlayerGameMapper gameMapper = new SinglePlayerGameMapper();

        public Game CreateGame(GameDifficulty difficulty)
        {
            Board board = BoardGenerator.GetInstance().CreateBoard(difficulty);
            
            SinglePlayerGame singlePlayerGame = new SinglePlayerGame(board, GetPlayerId());

            BuscaminasBE.SinglePlayerGame updatedGame = SaveGame(singlePlayerGame);
            // cuando el juego se guarda, la base crea ids para el juego y las celdas
            singlePlayerGame.UpdateIds(updatedGame);

            Analytics.GetInstance().Log(Event.SINGLE_PLAYER_GAME_START);

            return singlePlayerGame;
        }

        private int GetPlayerId()
        {
            return Authentication.GetInstance().UserId;
        }

        private BuscaminasBE.SinglePlayerGame SaveGame(SinglePlayerGame game)
        {
            return gameMapper.CreateNewGame(game.ToBEObject());
        }
    }
}
