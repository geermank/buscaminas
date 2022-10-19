using System.Collections;

namespace BuscaminasDomain.GameBoard.Iterator
{
    internal class BoardCellsIterator : IBoardIterator
    {
        private IEnumerator iterator;

        public BoardCellsIterator(BoardCell[,] cells)
        {
            iterator = cells.GetEnumerator();
        }

        public bool HasNext()
        {
            return iterator.MoveNext();
        }

        public BoardCell Next()
        {
            return (BoardCell) iterator.Current;
        }
    }
}
