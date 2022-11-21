using BuscaminasData;
using BuscaminasDomain.GameRules;
using System.Collections.Generic;

namespace BuscaminasDomain.GameLoader
{
    public abstract class MultiplayerGamesLoader : IGamesLoader
    {
        protected MultiPlayerGameMapper mapper = new MultiPlayerGameMapper();

        public abstract List<BuscaminasBE.InProgressGame> GetInProgressGames();

        public BuscaminasBE.Game LoadGame(int gameId)
        {
            BuscaminasBE.Game game = mapper.LoadMultiplayerGame(gameId);
            GameState gameState = (GameState) game.GameStateId;
            if (gameState == GameState.FINISHED)
            {
                game = null;
            }
            return game;
        }
    }
}
