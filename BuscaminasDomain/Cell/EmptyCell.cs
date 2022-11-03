using BuscaminasDomain.Cell;
using BuscaminasDomain.GameBoard;

namespace BuscaminasDomain
{
    internal class EmptyCell : BoardCell, IBEObjectConverter<BuscaminasBE.BoardCell>
    {
        internal EmptyCell(BoardPosition position) : base(position)
        {
            // empty constructor
        }

        internal EmptyCell(int id, bool selected, bool flagged, BoardPosition position) : base(id, selected, flagged, position)
        {
            // empty constructor
        }

        protected override void OnSelected(Board board, bool wasFlagged)
        {
            board.OnCellSelected(this, wasFlagged);
        }

        override public BuscaminasBE.BoardCell ToBEObject()
        {
            BuscaminasBE.BoardCell cell = base.ToBEObject();
            cell.TypeId = (int) CellType.EMPTY;
            return cell;
        }
    }
}