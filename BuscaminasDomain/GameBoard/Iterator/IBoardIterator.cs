using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasDomain.GameBoard.Iterator
{
    internal interface IBoardIterator
    {
        bool HasNext();
        BoardCell Next();
    }
}
