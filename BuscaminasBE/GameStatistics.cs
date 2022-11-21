namespace BuscaminasBE
{
    public class GameStatistics
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int singlePlayerResult;

        public int SinglePlayerGameResult {
            get { return singlePlayerResult; }
            set { singlePlayerResult = value; }
        }

        private int multiPlayerResult;

        public int MultiPlayerGameResult
        {
            get { return multiPlayerResult; }
            set { multiPlayerResult = value; }
        }

        private int boardHeight;

        public int BoardHeight
        {
            get { return boardHeight; }
            set { boardHeight = value; }
        }

        private int boardWidth;

        public int BoardWidth
        {
            get { return boardWidth; }
            set { boardWidth = value; }
        }

        private int numberOfMines;

        public int NumberOfMines
        {
            get { return numberOfMines; }
            set { numberOfMines = value; }
        }

        private int timePlayed;

        public int TimePlayed
        {
            get { return timePlayed; }
            set { timePlayed = value; }
        }
    }
}
