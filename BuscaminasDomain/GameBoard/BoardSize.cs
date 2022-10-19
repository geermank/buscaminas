namespace BuscaminasDomain.GameBoard
{
    internal class BoardSize
    {
        private readonly int width;
        private readonly int height;

        public BoardSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public bool ValidatePosition(BoardPosition position)
        {
            return ValidatePosition(position.X, position.Y);
        }

        public bool ValidatePosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < width && y < height;
        }
    }
}
