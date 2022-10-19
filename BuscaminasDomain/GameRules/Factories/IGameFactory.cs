using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasDomain.GameRules.Factories
{
    public interface IGameFactory
    {
        Game CreateGame(GameDifficulty difficulty, Player player);
    }
}
