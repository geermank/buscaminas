using BuscaminasDomain.GameBoard;
using System.Collections.Generic;

namespace BuscaminasDomain.GameRules
{
    public class MultiPlayerGame : Game
    {
        private const int MAX_UNCOVER_MINES_PER_TURN = 5;

        private Turn turn;
        private List<Player> players;
        private List<PlayerScore> playersScore;

        private int minesUncoveredThisTurn = 0;

        public List<Player> Players
        {
            get { return players; }
        }

        public override bool UserCanRestartGame()
        {
            return true;
        }

        internal MultiPlayerGame(Board board, List<Player> players) : base(board)
        {
            this.players = players;
            this.playersScore = CreatePlayersScore(players);
            this.turn = new Turn(players);
        }

        internal override void HandleEmptyCellSelected(EmptyCell emptyCell)
        {
            turn.ChangeTurn();
            ResetMinesUncoveredCounter();
        }

        internal override void HandleMineSelected(MineCell mine)
        {
            board.FlagCell(mine.Position);

            minesUncoveredThisTurn++;
            foreach(PlayerScore score in playersScore)
            {
                score.IncreaseScore(turn.CurrentPlayer);
            }
            if (minesUncoveredThisTurn > MAX_UNCOVER_MINES_PER_TURN)
            {
                turn.ChangeTurn();
                ResetMinesUncoveredCounter();
            }
        }

        internal override void HandleNumberSelected(NumberCell numberCell)
        {
            base.HandleNumberSelected(numberCell);
            turn.ChangeTurn();
            ResetMinesUncoveredCounter();
        }

        private void ResetMinesUncoveredCounter()
        {
            minesUncoveredThisTurn = 0;
        }

        private List<PlayerScore> CreatePlayersScore(List<Player> players)
        {
            List<PlayerScore> scores = new List<PlayerScore>();
            foreach(Player p in players)
            {
                PlayerScore score = new PlayerScore(p);
                scores.Add(score);
            }
            return scores;
        }

        protected override bool IsUserFlagEnabled()
        {
            return false;
        }
    }
}