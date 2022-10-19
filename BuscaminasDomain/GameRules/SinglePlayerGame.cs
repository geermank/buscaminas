using BuscaminasDomain.GameBoard;
using BuscaminasDomain.GameBoard.Iterator;

namespace BuscaminasDomain.GameRules
{
    public class SinglePlayerGame : Game
    {
        private Player player;

        public Player Player
        {
            get { return player; }
        }

        internal SinglePlayerGame(Board board, Player player) : base(board)
        {
            this.player = player;
        }

        public override bool UserCanRestartGame()
        {
            return true;
        }

        internal override void HandleMineSelected(MineCell mine)
        {
            listener?.ShowExploitedMine(mine.Position.X, mine.Position.Y);

            IBoardIterator iterator = board.GetIterator();
            while(iterator.HasNext())
            {
                BoardCell cell = iterator.Next();
                if (cell is MineCell && cell != mine)
                {
                    listener?.ShowNormalMine(cell.Position.X, cell.Position.Y);
                } else if (cell.Flagged)
                {
                    listener?.ShowMineCrossedOut(cell.Position.X, cell.Position.Y);
                }
            }

            gameState = GameState.LOST;
            listener?.OnLostGame();
        }

        protected override bool IsUserFlagEnabled()
        {
            return true;
        }

        protected override void HandleBoardCompleted()
        {
            IBoardIterator iterator = board.GetIterator();
            while (iterator.HasNext())
            {
                BoardCell next = iterator.Next();
                if (next.Selected || next.Flagged)
                {
                    continue;
                }
                if (next is NumberCell)
                {
                    listener?.ShowNumber(next.Position.X, next.Position.Y, (next as NumberCell).Number);
                } else if (next is EmptyCell)
                {
                    listener?.ShowEmptyCell(next.Position.X, next.Position.Y);
                }
            }

            gameState = GameState.FINISHED;

            base.HandleBoardCompleted();
        }
    }
}