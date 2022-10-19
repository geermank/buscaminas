using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuscaminasDomain
{
    public class Turn
    {
        private List<Player> players;
        private int currentPlayerIndex = 0;

        public Turn(List<Player> players)
        {
            this.players = players;
        }

        public Player CurrentPlayer
        {
            get { return players[currentPlayerIndex]; }
        }

        public void ChangeTurn()
        {
            currentPlayerIndex++;
            if (currentPlayerIndex >= players.Count)
            {
                currentPlayerIndex = 0;
            }
        }
    }
}