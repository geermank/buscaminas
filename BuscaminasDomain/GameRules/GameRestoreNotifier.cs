using BuscaminasDomain.GameBoard;
using BuscaminasDomain.GameBoard.Iterator;
using static BuscaminasDomain.GameRules.Game;

namespace BuscaminasDomain.GameRules
{
    internal class GameRestoreNotifier
    {
        public void NotifyGameRestored(Board board, IGameListener gameListener)
        {
            IBoardIterator boardIterator = board.GetIterator();
            while (boardIterator.HasNext())
            {
                BoardCell cell = boardIterator.Next();
                if (cell.Selected)
                {
                    if (cell is EmptyCell)
                    {
                        gameListener?.ShowEmptyCell(cell.Position.X, cell.Position.Y, board.RemainingMines);
                    }
                    else if (cell is NumberCell)
                    {
                        var number = (cell as NumberCell).Number;
                        gameListener?.ShowNumber(cell.Position.X, cell.Position.Y, number, board.RemainingMines);
                    }
                } else if (cell.Flagged)
                {
                    gameListener?.ShowFlag(cell.Position.X, cell.Position.Y, board.RemainingMines);
                }
            }
        }
    }
}
