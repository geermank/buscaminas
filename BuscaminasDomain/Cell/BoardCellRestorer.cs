using BuscaminasDomain.GameBoard;
using BuscaminasDomain.Utils;
using System;

namespace BuscaminasDomain.Cell
{
    internal class BoardCellRestorer
    {
        public BoardCell Restore(BuscaminasBE.BoardCell boardCell)
        {
            BoardCell cell;

            bool selected = IntegerToBoolConverter.GetBool(boardCell.Selected);
            bool flagged = IntegerToBoolConverter.GetBool(boardCell.Flagged);
            BoardPosition position = new BoardPosition(boardCell.X, boardCell.Y);

            CellType cellType = (CellType) boardCell.TypeId;
            switch(cellType)
            {
                case CellType.EMPTY:
                    cell = new EmptyCell(boardCell.Id, selected, flagged, position);
                    break;
                case CellType.MINE:
                    cell = new MineCell(boardCell.Id, selected, flagged, position);
                    break;
                case CellType.NUMBER:
                    cell = new NumberCell(boardCell.Id, selected, flagged, position, boardCell.Number);
                    break;
                default:
                    throw new ArgumentException("The given cell type is unknown");
            }

            return cell;
        }
    }
}
