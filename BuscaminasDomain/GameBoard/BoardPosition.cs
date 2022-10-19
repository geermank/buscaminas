namespace BuscaminasDomain.GameBoard
{
    public class BoardPosition
    {
        private readonly int x;
        private readonly int y;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public BoardPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is BoardPosition &&
                (obj as BoardPosition).x == x && 
                (obj as BoardPosition).y == y;
        }
    }
}
