using BuscaminasDomain.Cell;
using BuscaminasDomain.GameBoard;

namespace BuscaminasDomain
{
    internal class NumberCell : BoardCell, IBEObjectConverter<BuscaminasBE.BoardCell>
    {
        private readonly int number;

        internal NumberCell(int number, BoardPosition position) : this(0, false, false, position, number)
        {
            // empty constructor
        }

        internal NumberCell(int id, bool selected, bool flagged, BoardPosition position, int number) : base(id, selected, flagged, position)
        {
            this.number = number;
        }

        internal int Number
        {
            get { return number; }
        }

        protected override void OnSelected(Board board)
        {
            board.OnCellSelected(this);
        }

        override public BuscaminasBE.BoardCell ToBEObject()
        {
            BuscaminasBE.BoardCell cell = base.ToBEObject();
            cell.TypeId = (int) CellType.NUMBER;
            cell.Number = number;
            return cell;
        }
    }
}