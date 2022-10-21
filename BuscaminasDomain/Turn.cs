using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuscaminasDomain
{
    public class Turn
    {
        private List<Player> players;
        private int currentPlayerId = 0;

        public Turn(List<Player> players)
        {
            this.players = players;
        }

        public Player CurrentPlayer
        {
            get { return players[currentPlayerId]; }
        }

        public void ChangeTurn()
        {
            currentPlayerId++;
            if (currentPlayerId >= players.Count)
            {
                currentPlayerId = 0;
            }
        }
    }
}