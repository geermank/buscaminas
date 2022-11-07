using BuscaminasAuth;
using BuscaminasBE;
using System.Collections.Generic;

namespace BuscaminasDomain.GameLoader
{
    public class MultiplayerInProgressGamesLoader : MultiplayerGamesLoader
    {
        public override List<InProgressGame> GetInProgressGames()
        {
            return mapper.LoadInProgressGames(Authentication.GetInstance().UserId);
        }
    }
}
