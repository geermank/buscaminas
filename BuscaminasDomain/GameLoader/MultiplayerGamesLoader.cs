using BuscaminasData;
using System.Collections.Generic;

namespace BuscaminasDomain.GameLoader
{
    public abstract class MultiplayerGamesLoader : IGamesLoader
    {
        protected MultiPlayerGameMapper mapper = new MultiPlayerGameMapper();

        public abstract List<BuscaminasBE.InProgressGame> GetInProgressGames();

        public BuscaminasBE.Game LoadGame(int gameId)
        {
            return mapper.LoadMultiplayerGame(gameId);
        }
    }
}
