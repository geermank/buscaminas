using BuscaminasDomain.GameBoard;

namespace BuscaminasDomain
{
    internal class EmptyCell : BoardCell
    {
        internal EmptyCell(BoardPosition position) : base(position)
        {
            // empty constructor
        }

        protected override void OnSelected(Board board)
        {
            board.OnCellSelected(this);
        }
    }
}