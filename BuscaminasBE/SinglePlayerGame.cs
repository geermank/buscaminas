namespace BuscaminasBE
{
    public class SinglePlayerGame : Game
    {
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int resultId;

        public int ResultId
        {
            get { return resultId; }
            set { resultId = value; }
        }
    }
}
