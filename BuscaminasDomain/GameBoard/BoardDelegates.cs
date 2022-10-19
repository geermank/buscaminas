using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasDomain.GameBoard
{
    internal delegate void DelOnMineUncovered(MineCell mine);
    internal delegate void DelOnNumberUncovered(NumberCell mine);
    internal delegate void DelOnEmptyCellUncovered(EmptyCell mine);

    internal delegate void DelOnCellFlagged(BoardCell cell);

    internal delegate void DelOnBoardCompleted();
}
