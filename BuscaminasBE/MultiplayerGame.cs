using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasBE
{
    public class MultiplayerGame : Game
    {
        private int multiplayerResultId;

        public int MultiplayerResultId
        {
            get { return multiplayerResultId; }
            set { multiplayerResultId = value; }
        }
    }
}
