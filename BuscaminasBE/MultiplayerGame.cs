using System.Collections.Generic;

namespace BuscaminasBE
{
    public class MultiplayerGame : Game
    {
        private MultiplayerResult result;

        public MultiplayerResult MultiplayerResult
        {
            get { return result; }
            set { result = value; }
        }

        private Turn turn;

        public Turn Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        private List<Player> players;

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }
    }
}
