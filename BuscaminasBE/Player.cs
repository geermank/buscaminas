namespace BuscaminasBE
{
    public class Player
    {
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int gameId;

        public int GameId
        {
            get { return gameId; }
            set { gameId = value; }
        }

        private int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
