using BuscaminasData;
using BuscaminasDomain.GameBoard;
using BuscaminasDomain.GameBoard.Iterator;
using BuscaminasDomain.GameRules.Result;

namespace BuscaminasDomain.GameRules
{
    public class SinglePlayerGame : Game, IBEObjectConverter<BuscaminasBE.SinglePlayerGame>
    {
        private int playerId;
        private GameResult result = GameResult.NO_RESULT;

        private SinglePlayerGameMapper gameMapper = new SinglePlayerGameMapper();

        internal SinglePlayerGame(Board board, int playerId) : base(board)
        {
            this.playerId = playerId;
            this.gameState = GameState.IN_PROGRESS;
        }

        internal SinglePlayerGame(Board board, int playerId, int id, 
                                  GameState gameState, int timePlayedInSeconds, 
                                  GameResult result) : base(board, id, gameState, timePlayedInSeconds)
        {
            this.playerId = playerId;
            this.result = result;
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
            result = GameResult.LOST;

            listener?.OnLostGame();

            gameMapper.SaveGame(ToBEObject(), mine.ToBEObject());
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
                    listener?.ShowNumber(next.Position.X, next.Position.Y, (next as NumberCell).Number, 0);
                } else if (next is EmptyCell)
                {
                    listener?.ShowEmptyCell(next.Position.X, next.Position.Y, 0);
                }
            }

            gameState = GameState.FINISHED;
            result = GameResult.WIN;

            gameMapper.SaveGame(ToBEObject(), null);

            base.HandleBoardCompleted();
        }

        protected override bool CurrentUserCanPlay()
        {
            return true;
        }

        public BuscaminasBE.SinglePlayerGame ToBEObject()
        {
            BuscaminasBE.SinglePlayerGame game = new BuscaminasBE.SinglePlayerGame();
            game.Id = id;
            game.Board = board.ToBEObject();
            game.GameStateId = (int) gameState;
            game.TimePlayedInSeconds = timePlayedInSeconds;
            game.ResultId = (int) result;
            game.UserId = playerId;
            return game;
        }

        internal void UpdateIds(BuscaminasBE.SinglePlayerGame singlePlayerGame)
        {
            if (singlePlayerGame == null)
            {
                return;
            }
            id = singlePlayerGame.Id;
            playerId = singlePlayerGame.UserId;
            board.UpdateIds(singlePlayerGame.Board);
        }

        protected override GameMapper GetGameMapper()
        {
            return gameMapper;
        }
    }
}