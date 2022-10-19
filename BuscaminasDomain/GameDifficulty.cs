namespace BuscaminasDomain
{
    public class GameDifficulty
    {
        private string name;
        private int width;
        private int height;
        private int mines;

        public GameDifficulty(string name, int width, int height, int mines)
        {
            this.name = name;
            this.width = width;
            this.height = height;
            this.mines = mines;
        }

        public string Name
        {
            get { return name; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public int Mines
        {
            get { return mines; }
        }
    }
}