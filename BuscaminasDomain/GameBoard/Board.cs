using BuscaminasDomain.GameBoard.Iterator;

namespace BuscaminasDomain.GameBoard
{
    internal class Board
    {
        internal event DelOnMineUncovered OnMineUncovered;
        internal event DelOnNumberUncovered OnNumberUncovered;
        internal event DelOnEmptyCellUncovered OnEmptyCellUncovered;

        internal event DelOnCellFlagged DelOnCellFlagged;

        internal event DelOnBoardCompleted OnBoardCompleted;

        private readonly BoardCell[,] cells;
        private readonly BoardSize size;
        private readonly int numberOfMines;

        private int numberOfMinesFlagged = 0;
        private int numberOfCellsFlagged = 0;

        internal int NumberOfMines
        {
            get { return numberOfMines; }
        }

        internal int NumberOfMinesFlagged
        {
            get { return numberOfMinesFlagged; }
        }

        internal int NumberOfCellsFlagged
        {
            get { return numberOfCellsFlagged; }
        }

        internal Board(BoardCell[,] cells, BoardSize size, int numberOfMines)
        {
            this.cells = cells;
            this.size = size;
            this.numberOfMines = numberOfMines;
        }

        internal void SelectCell(BoardPosition position)
        {
            GetCellFromPosition(position)?.Select(this);
        }

        internal void FlagCell(BoardPosition position, bool forceFlag = false)
        {
            GetCellFromPosition(position)?.Flag(this, forceFlag);
        }

        internal void OnCellFlagged(BoardCell cell)
        {
            UpdateNumberOfCellsFlagged(cell);
            DelOnCellFlagged(cell);
            CheckBoardCompleted();
        }

        internal void OnCellSelected(MineCell mine)
        {
            OnMineUncovered(mine);
        }

        internal void OnCellSelected(EmptyCell emptyCell)
        {
            IBoardIterator neighboursIterator = new CellNeighboursIterator(cells, emptyCell, size);
            while(neighboursIterator.HasNext())
            {
                BoardCell cell = neighboursIterator.Next();
                cell?.Select(this);
            }
            OnEmptyCellUncovered(emptyCell);
        }

        internal void OnCellSelected(NumberCell number)
        {
            OnNumberUncovered(number);
        }

        internal IBoardIterator GetIterator()
        {
            return new BoardCellsIterator(cells);
        }

        private BoardCell GetCellFromPosition(BoardPosition position)
        {
            if (!size.ValidatePosition(position))
            {
                return null;
            }
            return cells[position.X, position.Y];
        }

        private void CheckBoardCompleted()
        {
            if (numberOfMinesFlagged == numberOfMines 
                && numberOfCellsFlagged == numberOfMines)
            {
                OnBoardCompleted();
            }
        }

        private void UpdateNumberOfCellsFlagged(BoardCell cell)
        {
            if (cell == null)
            {
                return;
            }
            if (cell.Flagged)
            {
                numberOfCellsFlagged++;
                if (cell is MineCell)
                {
                    numberOfMinesFlagged++;
                }
            }
            else
            {
                numberOfCellsFlagged--;
                if (cell is MineCell)
                {
                    numberOfMinesFlagged--;
                }
            }
        }
    }
}
