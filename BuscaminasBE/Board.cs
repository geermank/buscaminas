namespace BuscaminasBE
{
    public class Board
    {
        private BoardCell[,] cells;

        public BoardCell[,] Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        private int width;
        
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        private int numberOfMines;

        public int NumberOfMines
        {
            get { return numberOfMines; }
            set { numberOfMines = value; }
        }

        private int numberOfMinesFlagged;

        public int NumberOfMinesFlagged
        {
            get { return numberOfMinesFlagged; }
            set { numberOfMinesFlagged = value; }
        }

        private int numberOfCellsFlagged;

        public int NumberOfCellsFlagged
        {
            get { return numberOfCellsFlagged; }
            set { numberOfCellsFlagged = value; }
        }
    }
}
