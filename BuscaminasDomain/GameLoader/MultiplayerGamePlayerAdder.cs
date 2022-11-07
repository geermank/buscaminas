using BuscaminasAuth;
using BuscaminasData;

namespace BuscaminasDomain.GameLoader
{
    public class MultiplayerGamePlayerAdder
    {
        private Authentication auth = Authentication.GetInstance();
        private MultiPlayerGameMapper mapper = new MultiPlayerGameMapper(); 

        public BuscaminasBE.MultiplayerGame AddPlayerToGame(int gameId)
        {
            return mapper.JoinGame(gameId, auth.UserId);
        }
    }
}
