using BuscaminasDomain.GameBoard;

namespace BuscaminasDomain
{
    internal abstract class BoardCell
    {
        private BoardPosition position;
        private bool selected = false;
        private bool flagged = false;

        internal BoardCell(BoardPosition position)
        {
            this.position = position;
        }

        internal bool Selected
        {
            get { return selected; }
        }

        internal bool Flagged
        {
            get { return flagged; }
        }

        internal BoardPosition Position
        {
            get { return position; }
        }

        internal void Select(Board board)
        {
            if (selected)
            {
                return;
            }
            selected = true;
            OnSelected(board);
        }

        internal void Flag()
        {
            flagged = !flagged;
        }

        protected abstract void OnSelected(Board board);
    }
}