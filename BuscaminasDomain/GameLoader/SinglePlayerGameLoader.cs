using BuscaminasAuth;
using BuscaminasBE;
using BuscaminasData;
using BuscaminasDomain.GameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasDomain.GameLoader
{
    public class SinglePlayerGameLoader : IGamesLoader
    {
        private SinglePlayerGameMapper mapper = new SinglePlayerGameMapper();

        public List<InProgressGame> GetInProgressGames()
        {
            if (!Authentication.GetInstance().UserLogged)
            {
                return new List<InProgressGame>();
            }
            return mapper.LoadInProgressGames(Authentication.GetInstance().UserId);
        }

        public BuscaminasBE.Game LoadGame(int gameId)
        {
            BuscaminasBE.Game game = mapper.LoadGame(gameId);
            GameState gamestate = (GameState) game.GameStateId;
            if (gamestate == GameState.FINISHED)
            {
                game = null;
            }
            return game; 
        }
    }
}
