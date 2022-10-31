using BuscaminasDomain.Cell;
using BuscaminasDomain.GameBoard;
using BuscaminasDomain.GameRules.Result;

namespace BuscaminasDomain.GameRules.Factories
{
    public class SinglePlayerGameRestorer : SinglePlayerGameFactory
    {
        private BuscaminasBE.SinglePlayerGame singlePlayerGame;
        private bool gameRestored;

        private BoardCellRestorer cellsRestorer;

        public SinglePlayerGameRestorer(BuscaminasBE.SinglePlayerGame singlePlayerGame)
        {
            this.singlePlayerGame = singlePlayerGame;
            this.cellsRestorer = new BoardCellRestorer();
        }

        public override Game CreateGame(GameDifficulty difficulty)
        {
            Game game;
            if (gameRestored)
            {
                // deja al usuario seguir jugando nuevas partidas después 
                // de terminar la que está en curso
                game = base.CreateGame(difficulty);
            } else
            {
                GameState gameState = (GameState) singlePlayerGame.GameStateId;
                GameResult gameResult = (GameResult) singlePlayerGame.ResultId;
                game = new SinglePlayerGame(RestoreBoard(), singlePlayerGame.UserId, singlePlayerGame.Id, 
                    gameState, singlePlayerGame.TimePlayedInSeconds, gameResult);

                gameRestored = true;
                singlePlayerGame = null;
            }
            return game;
        }

        private Board RestoreBoard()
        {
            BoardSize boardSize = new BoardSize(singlePlayerGame.Board.Width, singlePlayerGame.Board.Height);
            return new Board(RestoreCells(), boardSize, singlePlayerGame.Board.NumberOfMines,
                singlePlayerGame.Board.NumberOfCellsFlagged, singlePlayerGame.Board.NumberOfMinesFlagged);
        }

        private BoardCell[,] RestoreCells()
        {
            var boardCells = new BoardCell[singlePlayerGame.Board.Width, singlePlayerGame.Board.Height];
             foreach(BuscaminasBE.BoardCell cell in singlePlayerGame.Board.Cells)
            {
                BoardCell restoredCell = cellsRestorer.Restore(cell);
                boardCells[cell.X, cell.Y] = restoredCell;
            }
            return boardCells;
        }
    }
}
