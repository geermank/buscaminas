using BuscaminasDomain.GameBoard.Iterator;

namespace BuscaminasDomain.GameBoard
{
    internal class Board : IBEObjectConverter<BuscaminasBE.Board>
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

        internal int RemainingMines
        {
            get { return numberOfMines - numberOfCellsFlagged; }
        }

        internal Board(BoardCell[,] cells, BoardSize size, int numberOfMines)
        {
            this.cells = cells;
            this.size = size;
            this.numberOfMines = numberOfMines;
        }

        internal Board(BoardCell[,] cells, BoardSize size, int numberOfMines,
            int numberOfCellsFlagged, int numberOfMinesFlagged) : this(cells, size, numberOfMines)
        {
            this.numberOfCellsFlagged = numberOfCellsFlagged;
            this.numberOfMinesFlagged = numberOfMinesFlagged;
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
            while (neighboursIterator.HasNext())
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

        public BuscaminasBE.Board ToBEObject()
        {
            BuscaminasBE.Board board = new BuscaminasBE.Board();
            board.Width = size.Width;
            board.Height = size.Height;
            board.NumberOfMines = numberOfMines;
            board.NumberOfMinesFlagged = numberOfMinesFlagged;
            board.NumberOfCellsFlagged = numberOfCellsFlagged;

            BuscaminasBE.BoardCell[,] beCells = new BuscaminasBE.BoardCell[size.Width, size.Height];
            for(int x = 0; x < size.Width; x++)
            {
                for(int y = 0; y < size.Height; y++)
                {
                    beCells[x, y] = this.cells[x, y].ToBEObject();
                }
            }
            board.Cells = beCells;

            return board;
        }

        internal void UpdateIds(BuscaminasBE.Board board)
        {
            for(int x = 0; x < size.Width; x++)
            {
                for(int y = 0; y < size.Height; y++)
                {
                    cells[x,y].Id = board.Cells[x,y].Id;
                }
            }
        }
    }
}
