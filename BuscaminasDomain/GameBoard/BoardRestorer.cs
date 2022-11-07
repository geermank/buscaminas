using BuscaminasDomain.Cell;

namespace BuscaminasDomain.GameBoard
{
    internal class BoardRestorer
    {
        private BoardCellRestorer cellsRestorer;

        public BoardRestorer()
        {
            this.cellsRestorer = new BoardCellRestorer();
        }

        public Board RestoreBoard(BuscaminasBE.Board board)
        {
            BoardSize boardSize = new BoardSize(board.Width, board.Height);
            return new Board(RestoreCells(board), boardSize, board.NumberOfMines, board.NumberOfCellsFlagged, board.NumberOfMinesFlagged);
        }

        private BoardCell[,] RestoreCells(BuscaminasBE.Board board)
        {
            var boardCells = new BoardCell[board.Width, board.Height];
            foreach (BuscaminasBE.BoardCell cell in board.Cells)
            {
                BoardCell restoredCell = cellsRestorer.Restore(cell);
                boardCells[cell.X, cell.Y] = restoredCell;
            }
            return boardCells;
        }
    }
}
