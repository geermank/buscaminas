using BuscaminasDomain.GameBoard;

namespace BuscaminasDomain.GameRules.Factories.Restorers
{
    public abstract class GameRestorer : IGameFactory
    {
        private IGameFactory gameFactory;
        private BuscaminasBE.Game gameToRestore;

        internal BoardRestorer boardRestorer;

        public GameRestorer(IGameFactory gameFactory, BuscaminasBE.Game gameToRestore)
        {
            this.gameFactory = gameFactory;
            this.gameToRestore = gameToRestore;
        } 

        public Game CreateGame(GameDifficulty difficulty)
        {
            Game newGame;
            if (gameToRestore == null)
            {
                newGame = gameFactory.CreateGame(difficulty);
            } else
            {
                newGame = RestoreGame(gameToRestore);
                gameToRestore = null;
            }
            return newGame;
        }

        protected abstract Game RestoreGame(BuscaminasBE.Game game);
    }
}
