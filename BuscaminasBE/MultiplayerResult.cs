namespace BuscaminasBE
{
    public class MultiplayerResult
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int resultId;

        public int ResultId
        {
            get { return resultId; }
            set { resultId = value; }
        }

        private int winner;

        public int Winner { 
            get { return winner; }
            set { winner = value; }
        }
    }
}
