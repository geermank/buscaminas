using BuscaminasData;
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
            void ShowEmptyCell(int x, int y, int remainingMines);
            void ShowNumber(int x, int y, int number, int remainingMines);
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

        internal protected int timePlayedInSeconds = 0;

        internal protected IGameListener listener;

        private GameRestoreNotifier gameRestorer = new GameRestoreNotifier(); 
        private bool isRestoredGame = false;

        internal Game(Board board)
        {
            this.board = board;
            this.board.OnNumberUncovered += HandleNumberSelected;
            this.board.OnEmptyCellUncovered += HandleEmptyCellSelected;
            this.board.OnMineUncovered += HandleMineSelected;
            this.board.DelOnCellFlagged += HandleCellFlagged;
            this.board.OnBoardCompleted += HandleBoardCompleted;
        }

        internal Game(Board board, int id, GameState gameState, int timePlayedInSeconds) : this(board)
        {
            this.id = id;
            this.gameState = gameState;
            this.timePlayedInSeconds = timePlayedInSeconds;
            this.isRestoredGame = true;
        }

        public int TimePlayedInSeconds
        {
            get { return timePlayedInSeconds; }
            set { timePlayedInSeconds = value; }
        }

        public int Id
        {
            get { return id; }
            internal set { id = value; }
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
            RestoreGameIfNeeded();
        }

        public void SelectCell(int x, int y)
        {
            if (CurrentUserCanPlay())
            {
                board.SelectCell(new BoardPosition(x, y));
            }
        }

        public void FlagCell(int x, int y)
        {
            if(IsUserFlagEnabled() && CurrentUserCanPlay())
            {
                board.FlagCell(new BoardPosition(x, y));
            }
        }

        protected virtual void HandleBoardCompleted()
        {
            gameState = GameState.FINISHED;
            listener.OnGameWon();
        }

        internal abstract void HandleMineSelected(MineCell mine);

        internal virtual void HandleNumberSelected(NumberCell numberCell)
        {
            GetGameMapper().SaveSelectMove(id, timePlayedInSeconds, numberCell.ToBEObject(), board.ToBEObject());
            listener?.ShowNumber(numberCell.Position.X, numberCell.Position.Y, numberCell.Number, board.RemainingMines);
        }

        internal virtual void HandleEmptyCellSelected(EmptyCell emptyCell)
        {
            GetGameMapper().SaveSelectMove(id, timePlayedInSeconds, emptyCell.ToBEObject(), board.ToBEObject());
            listener?.ShowEmptyCell(emptyCell.Position.X, emptyCell.Position.Y, board.RemainingMines);
        }

        internal virtual void HandleCellFlagged(BoardCell boardCell)
        {
            GetGameMapper().SaveFlagMove(id, board.ToBEObject(), boardCell.ToBEObject(), timePlayedInSeconds);
            if (boardCell.Flagged)
            {
                listener?.ShowFlag(boardCell.Position.X, boardCell.Position.Y, board.RemainingMines);
            } else
            {
                listener?.RemoveFlag(boardCell.Position.X, boardCell.Position.Y, board.RemainingMines);
            }
        }

        private void RestoreGameIfNeeded()
        {
            if (!isRestoredGame)
            {
                return;
            }
            gameRestorer.NotifyGameRestored(board, listener);
        }

        public abstract bool CanBeRestarted();
        protected abstract bool IsUserFlagEnabled();
        protected abstract bool CurrentUserCanPlay();
        protected abstract GameMapper GetGameMapper();
        protected virtual void OnListenerAttached()
        {
            // let the children decide whether they want to react to a new listener or not
        }
    }
}