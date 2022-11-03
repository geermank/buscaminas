namespace BuscaminasBE
{
    public class Turn
    {
        private int? currentPlayerId;

        public int? CurrentPlayerId
        {
            get { return currentPlayerId; }
            set { currentPlayerId = value; }
        }

        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
    }
}
