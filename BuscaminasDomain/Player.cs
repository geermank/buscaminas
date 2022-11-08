using BuscaminasDomain.Utils;

namespace BuscaminasDomain
{
    public class Player : IBEObjectConverter<BuscaminasBE.Player>, ICompetitor<Player>
    {
        private int userId;
        private string name;
        private int score;

        public string Name
        {
            get { return name; }
        }

        public int UserId
        {
            get { return userId; }
        }

        public int Score
        {
            get { return score; }
        }

        public Player()
        {

        }

        public Player(BuscaminasBE.Player player)
        {
            this.userId = player.UserId;
            this.name = player.Name;
            this.score = player.Score;
        }

        public Player(BuscaminasBE.User user)
        {
            name = user.Name;
            userId = user.Id;
            score = 0;
        }

        public Player(int userId, string name, int score)
        {
            this.userId = userId;
            this.name = name;
            this.score = score;
        }

        public void IncrementScore()
        {
            score++;
        }

        public BuscaminasBE.Player ToBEObject()
        {
            BuscaminasBE.Player player = new BuscaminasBE.Player();
            player.UserId = userId;
            player.Score = score;
            return player;
        }

        public Player Oust(Player rival)
        {
            Player champion = null;
            if (rival.Score > Score)
            {
                champion = rival;
            }
            else if (rival.Score < Score)
            {
                champion = this;
            }
            return champion;
        }
    }
}