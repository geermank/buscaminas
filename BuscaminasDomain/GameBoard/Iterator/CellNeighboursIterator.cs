namespace BuscaminasDomain.GameBoard.Iterator
{
    internal class CellNeighboursIterator : IBoardIterator
    {
        private const int X_VALUES = 0;
        private const int Y_VALUES = 1;

        private readonly BoardCell[,] cells;
        private readonly BoardCell target;
        private readonly BoardSize boardSize;

        private readonly int[,] moves = {
            { -1, 0 },
            { -1, 1 },
            { 0, 1 },
            { 1, 1 },
            { 1, 0 },
            { 1, -1 },
            { 0, -1 },
            { -1, -1 }
        };

        private int movesIndex = -1;

        internal CellNeighboursIterator(BoardCell[,] cells, BoardCell target, BoardSize boardSize)
        {
            this.cells = cells;
            this.target = target;
            this.boardSize = boardSize;
        }

        public bool HasNext()
        {
            return movesIndex < (moves.Length / 2);
        }

        public BoardCell Next()
        {
            movesIndex++;
            if (!HasNext())
            {
                return null;
            }
            int nextX = NextX();
            int nextY = NextY();
            if (boardSize.ValidatePosition(nextX, nextY))
            {
                return cells[nextX, nextY];
            } else
            {
                return Next();
            }
        }

        private int NextX()
        {
            return target.Position.X + moves[movesIndex, X_VALUES];
        }

        private int NextY()
        {
            return target.Position.Y + moves[movesIndex, Y_VALUES];
        }
    }
}
