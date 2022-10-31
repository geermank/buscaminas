namespace BuscaminasBE
{
    public class InProgressGame
    {
        private int gameId;

        public int GameId
        {
            get { return gameId; }
            set { gameId = value; }
        }

        private int boardWidth;

        public int BoardWidth
        {
            get { return boardWidth; }
            set { boardWidth = value; }
        }

        private int boardHeight;

        public int BoardHeight
        {
            get { return boardHeight; }
            set { boardHeight = value; }
        }

        private int totalMines;

        public int TotalMines
        {
            get { return totalMines; }
            set { totalMines = value; }
        }

        private int remainingMines;

        public int RemaningMines
        {
            get { return remainingMines; }
            set { remainingMines = value; }
        }
    }
}
