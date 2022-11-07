using System.Collections.Generic;

namespace BuscaminasDomain
{
    public class Turn : IBEObjectConverter<BuscaminasBE.Turn>
    {
        private List<Player> players;
        private int? currentPlayerId = null;
        private int turnNumber = 0;

        public Turn(List<Player> players)
        {
            this.players = players;
            this.currentPlayerId = players[0].UserId;
        }

        public Turn(List<Player> players, int? currentPlayerId, int turnNumber)
        {
            this.players = players;
            this.currentPlayerId = currentPlayerId;
            this.turnNumber = turnNumber;
        }

        public Player CurrentPlayer
        {
            get {
                if (currentPlayerId == null)
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
            int index = players.IndexOf(CurrentPlayer);
            if (index == -1)
            {
                return;
            }

            turnNumber++;
            
            if (players.Count == 1)
            {
                currentPlayerId = null;
                return;
            }
            int nextIndex = index++;
            if (nextIndex >= players.Count)
            {
                nextIndex = 0;
            }
            currentPlayerId = players[nextIndex].UserId;
        }

        public BuscaminasBE.Turn ToBEObject()
        {
            BuscaminasBE.Turn turn = new BuscaminasBE.Turn();
            turn.Number = turnNumber;
            turn.CurrentPlayerId = currentPlayerId;
            return turn;
        }
    }
}