using BuscaminasDomain.GameBoard;
using BuscaminasDomain.Utils;

namespace BuscaminasDomain
{
    internal abstract class BoardCell : IBEObjectConverter<BuscaminasBE.BoardCell>
    {
        private int id;
        private BoardPosition position;
        private bool selected = false;
        private bool flagged = false;

        internal BoardCell(BoardPosition position)
        {
            this.position = position;
        }

        internal BoardCell(int id, bool selected, bool flagged, BoardPosition position) : this(position)
        {
            this.id = id;
            this.selected = selected;
            this.flagged = flagged;
        }

        internal int Id
        {
            get { return id; }
            set { id = value; }
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
            OnSelected(board, flagged);
            flagged = false;
        }

        internal void Flag(Board board, bool forceFlag)
        {
            if (selected && !forceFlag)
            {
                return;
            }
            flagged = !flagged;
            board.OnCellFlagged(this);
        }

        protected abstract void OnSelected(Board board, bool wasFlagged);

        public virtual BuscaminasBE.BoardCell ToBEObject()
        {
            BuscaminasBE.BoardCell cell = new BuscaminasBE.BoardCell();
            cell.Id = id;
            cell.X = position.X;
            cell.Y = position.Y;
            cell.Flagged = IntegerToBoolConverter.GetInt(flagged);
            cell.Selected = IntegerToBoolConverter.GetInt(selected);

            return cell;
        }
    }
}