using BuscaminasDomain.GameBoard;

namespace BuscaminasDomain
{
    internal class MineCell : BoardCell
    {
        internal MineCell(BoardPosition position) : base(position)
        {
            // empty constructor
        }

        protected override void OnSelected(Board board)
        {
            board.OnCellSelected(this);
        }
    }
}