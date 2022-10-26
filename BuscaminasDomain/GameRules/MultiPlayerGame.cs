using BuscaminasAuth;
using BuscaminasDomain.GameBoard;
using System.Collections.Generic;

namespace BuscaminasDomain.GameRules
{
    public class MultiPlayerGame : Game, IBEObjectConverter<BuscaminasBE.MultiplayerGame>
    {
        private const int MAX_UNCOVER_MINES_PER_TURN = 5;

        private Turn turn;
        private List<Player> players;

        private int minesUncoveredThisTurn = 0;

        public List<Player> Players
        {
            get { return players; }
        }

        public override bool UserCanRestartGame()
        {
            return false;
        }

        internal MultiPlayerGame(Board board, List<Player> players) : base(board)
        {
            this.players = players;
            this.turn = new Turn(players);
        }

        protected override void OnListenerAttached()
        {
            listener.OnPlayerTurnChanged(turn.CurrentPlayer, false);

            Player p1 = players[0];
            Player p2 = null;
            if (players.Count == 2)
            {
                p2 = players[1];
            }
            listener.ShowPlayers(p1, p2);
        }

        internal override void HandleEmptyCellSelected(EmptyCell emptyCell)
        {
            base.HandleEmptyCellSelected(emptyCell);
            turn.ChangeTurn();
            ResetMinesUncoveredCounter();
            
            listener.OnPlayerTurnChanged(turn.CurrentPlayer, true);
        }

        internal override void HandleMineSelected(MineCell mine)
        {
            board.FlagCell(mine.Position, true);
            turn.CurrentPlayer?.IncrementScore();

            minesUncoveredThisTurn++;

            if (minesUncoveredThisTurn > MAX_UNCOVER_MINES_PER_TURN)
            {
                turn.ChangeTurn();
                ResetMinesUncoveredCounter();
                listener.OnPlayerTurnChanged(turn.CurrentPlayer, true);
            }
        }

        internal override void HandleNumberSelected(NumberCell numberCell)
        {
            base.HandleNumberSelected(numberCell);
            turn.ChangeTurn();
            ResetMinesUncoveredCounter();
            listener.OnPlayerTurnChanged(turn.CurrentPlayer, true);
        }

        private void ResetMinesUncoveredCounter()
        {
            minesUncoveredThisTurn = 0;
        }

        protected override bool IsUserFlagEnabled()
        {
            return false;
        }

        protected override bool CurrentUserCanPlay()
        {
            Player currentPlayer = players.Find(p => p.UserId == Authentication.GetInstance().UserId);
            return turn.CanPlay(currentPlayer);
        }

        public BuscaminasBE.MultiplayerGame ToBEObject()
        {
            return new BuscaminasBE.MultiplayerGame();
        }
    }
}