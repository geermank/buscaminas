namespace BuscaminasDomain
{
    public class PlayerScore
    {
        private Player player;
        private int score;

        public int Score
        {
            get { return score; }
        }
        
        public PlayerScore(Player player)
        {
            this.player = player;
        }

        public void IncreaseScore(Player player)
        {
            if (this.player.Equals(player))
            {
                score++;
            }
        }
    }
}