using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasDomain
{
    public interface IBEObjectConverter<T>
    {
        T ToBEObject();
    }
}
