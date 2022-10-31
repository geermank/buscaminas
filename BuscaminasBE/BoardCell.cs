namespace BuscaminasBE
{
    public class BoardCell
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int boardId;

        public int BoardId
        {
            get { return boardId; }
            set { boardId = value; }
        }

        private int typeId;

        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }

        private int number = -1;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        private int flagged;

        public int Flagged
        {
            get { return flagged; }
            set { flagged = value; }
        }

        private int selected;

        public int Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
