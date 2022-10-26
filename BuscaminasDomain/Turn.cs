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
        private int turnNumber = 0;

        public Turn(List<Player> players)
        {
            this.players = players;
            this.currentPlayerId = players[0].UserId;
        }

        public Turn(List<Player> players, int currentPlayerId, int turnNumber)
        {
            this.players = players;
            this.currentPlayerId = currentPlayerId;
            this.turnNumber = turnNumber;
        }

        public Player CurrentPlayer
        {
            get {
                if (currentPlayerId == -1)
                {
                    return null;
                }
                return players.Find(p => p.UserId == currentPlayerId);
            }
        }

        public bool CanPlay(Player player) 
        {
            return currentPlayerId == player.UserId && players.Count > 1 ||
                currentPlayerId == player.UserId && players.Count == 1 && turnNumber == 0;
        }


        public void ChangeTurn()
        {
            if (players.Count == 1)
            {
                currentPlayerId = -1;
                return;
            }
            int index = players.IndexOf(CurrentPlayer);
            if (index == -1)
            {
                return;
            }
            int nextIndex = index++;
            if (nextIndex >= players.Count)
            {
                nextIndex = 0;
            }
            currentPlayerId = players[nextIndex].UserId;
            turnNumber++;
        }
    }
}