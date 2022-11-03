using BuscaminasAuth;
using BuscaminasBE;
using System.Collections.Generic;

namespace BuscaminasDomain.GameLoader
{
    public class MultiplayerRoomsLoader : MultiplayerGamesLoader
    {
        public override List<InProgressGame> GetInProgressGames()
        {
            return mapper.LoadOpenRooms(Authentication.GetInstance().UserId);
        }
    }
}
