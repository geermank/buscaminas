namespace BuscaminasDomain.GameRules.Result
{
    internal class MultiplayerGameResult
    {
        private GameResult gameResult;

        public GameResult GameResult
        {
            get { return gameResult; }
            set { gameResult = value; }
        }

        private Player winner;

        public Player Winner
        {
            get { return winner; }
            set { winner = value; }
        }
    }
}
