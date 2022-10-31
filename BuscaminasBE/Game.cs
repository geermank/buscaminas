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

        private Board board;

        public Board Board
        {
            get { return board; }
            set { board = value; }
        }
    }
}
