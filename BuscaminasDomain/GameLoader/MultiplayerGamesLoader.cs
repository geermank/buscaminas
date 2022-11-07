using BuscaminasBE;
using BuscaminasData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasDomain.GameLoader
{
    public abstract class MultiplayerGamesLoader : IGamesLoader
    {
        protected MultiPlayerGameMapper mapper = new MultiPlayerGameMapper();

        public abstract List<InProgressGame> GetInProgressGames();

        public Game LoadGame(int gameId)
        {
            return mapper.LoadMultiplayerGame(gameId);
        }
    }
}
