using BuscaminasDomain.GameBoard;
using BuscaminasDomain.GameBoard.Iterator;

namespace BuscaminasDomain.GameRules
{
    public class SinglePlayerGame : Game
    {
        private int playerId;

        internal SinglePlayerGame(Board board, int playerId) : base(board)
        {
            this.playerId = playerId;
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

            gameState = GameState.FINISHED;
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

        protected override bool CurrentUserCanPlay()
        {
            return true;
        }
    }
}