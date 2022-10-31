using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasDomain.GameLoader
{
    public interface IGamesLoader
    {
        List<BuscaminasBE.InProgressGame> GetInProgressGames();
        BuscaminasBE.Game LoadGame(int gameId);
    }
}
