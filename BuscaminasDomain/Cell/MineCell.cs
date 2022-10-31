using BuscaminasDomain.Cell;
using BuscaminasDomain.GameBoard;

namespace BuscaminasDomain
{
    internal class MineCell : BoardCell, IBEObjectConverter<BuscaminasBE.BoardCell>
    {
        internal MineCell(BoardPosition position) : base(position)
        {
            // empty constructor
        }

        internal MineCell(int id, bool selected, bool flagged, BoardPosition position) : base(id, selected, flagged, position)
        {
            // empty constructor
        }

        protected override void OnSelected(Board board)
        {
            board.OnCellSelected(this);
        }

        override public BuscaminasBE.BoardCell ToBEObject()
        {
            BuscaminasBE.BoardCell cell = base.ToBEObject();
            cell.TypeId = (int) CellType.MINE;
            return cell;
        }
    }
}