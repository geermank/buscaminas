using BuscaminasDomain.GameBoard;

namespace BuscaminasDomain
{
    internal class NumberCell : BoardCell
    {
        private readonly int number;

        internal NumberCell(int number, BoardPosition position) : base(position)
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
    }
}