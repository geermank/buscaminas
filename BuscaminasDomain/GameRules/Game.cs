using BuscaminasDomain.GameBoard;

namespace BuscaminasDomain.GameRules
{
    public abstract class Game
    {
        public interface IGameListener
        {
            void ShowExploitedMine(int x, int y);
            void ShowNormalMine(int x, int y);
            void ShowMineCrossedOut(int x, int y);
            void ShowEmptyCell(int x, int y);
            void ShowNumber(int x, int y, int number);
            void ShowFlag(int x, int y, int remainingMines);
            void RemoveFlag(int x, int y, int remainingMines);
            void OnLostGame();
            void OnGameWon();
            void OnPlayerTurnChanged(Player player, bool stopTimer);
            void ShowPlayers(Player player1, Player player2);
        }

        internal int id;

        internal Board board;
        internal GameState gameState = GameState.PENDING;

        internal int timePlayedInSeconds = 0;

        internal protected IGameListener listener;

        internal Game(Board board)
        {
            this.board = board;
            this.board.OnNumberUncovered += HandleNumberSelected;
            this.board.OnEmptyCellUncovered += HandleEmptyCellSelected;
            this.board.OnMineUncovered += HandleMineSelected;
            this.board.DelOnCellFlagged += HandleCellFlagged;
            this.board.OnBoardCompleted += HandleBoardCompleted;
        }

        public int TimePlayedInSeconds
        {
            get { return timePlayedInSeconds; }
            set { timePlayedInSeconds = value; }
        }

        public void IncrementTimePlayed()
        {
            timePlayedInSeconds++;
        }

        public bool IsFinished()
        {
            return gameState == GameState.FINISHED;
        }

        public void SetGameListener(IGameListener listener)
        {
            this.listener = listener;
            OnListenerAttached();
        }

        public void LeftClickCell(int x, int y)
        {
            if (CurrentUserCanPlay())
            {
                board.SelectCell(new BoardPosition(x, y));
            }
        }

        public void RightClickCell(int x, int y)
        {
            if(IsUserFlagEnabled() && CurrentUserCanPlay())
            {
                board.FlagCell(new BoardPosition(x, y));
            }
        }

        protected virtual void HandleBoardCompleted()
        {
            listener.OnGameWon();
        }

        internal abstract void HandleMineSelected(MineCell mine);

        internal virtual void HandleNumberSelected(NumberCell numberCell)
        {
            listener?.ShowNumber(numberCell.Position.X, numberCell.Position.Y, numberCell.Number);
        }

        internal virtual void HandleEmptyCellSelected(EmptyCell emptyCell)
        {
            listener?.ShowEmptyCell(emptyCell.Position.X, emptyCell.Position.Y);
        }

        internal virtual void HandleCellFlagged(BoardCell boardCell)
        {
            int remainingMines = board.NumberOfMines - board.NumberOfCellsFlagged;
            if (boardCell.Flagged)
            {
                listener?.ShowFlag(boardCell.Position.X, boardCell.Position.Y, remainingMines);
            } else
            {
                listener?.RemoveFlag(boardCell.Position.X, boardCell.Position.Y, remainingMines);
            }
        }

        public abstract bool UserCanRestartGame();
        protected abstract bool IsUserFlagEnabled();
        protected abstract bool CurrentUserCanPlay();
        protected virtual void OnListenerAttached()
        {
            // let the children decide whether they want to react to a new listener or not
        }
    }
}