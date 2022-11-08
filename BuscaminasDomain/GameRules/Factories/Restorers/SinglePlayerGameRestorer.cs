using BuscaminasDomain.GameRules.Factories.Restorers;
using BuscaminasDomain.GameRules.Result;

namespace BuscaminasDomain.GameRules.Factories.Restorers
{
    public class SinglePlayerGameRestorer : GameRestorer
    {

        public SinglePlayerGameRestorer(BuscaminasBE.SinglePlayerGame singlePlayerGame)
            : base(new SinglePlayerGameFactory(), singlePlayerGame)
        {
            // empty constructor body
        }

        protected override Game RestoreGame(BuscaminasBE.Game game)
        {
            BuscaminasBE.SinglePlayerGame singlePlayerGame = (BuscaminasBE.SinglePlayerGame) game;

            GameState gameState = (GameState)singlePlayerGame.GameStateId;
            GameResult gameResult = (GameResult)singlePlayerGame.ResultId;
            return new SinglePlayerGame(boardRestorer.RestoreBoard(singlePlayerGame.Board),
                singlePlayerGame.UserId, singlePlayerGame.Id, gameState,
                singlePlayerGame.TimePlayedInSeconds, gameResult);
        }
    }
}
