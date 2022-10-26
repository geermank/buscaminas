using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasBE
{
    public abstract class Game
    {
        private int id;

        public int Id { 
            get { return id; } 
            set { id = value; }
        }

        private int gameStateId;

        public int GameStateId
        {
            get { return gameStateId; }
            set { gameStateId = value; }
        }

        private int timePlayedInSeconds;

        public int TimePlayedInSeconds
        {
            get { return timePlayedInSeconds; }
            set { timePlayedInSeconds = value; }
        }
    }
}
