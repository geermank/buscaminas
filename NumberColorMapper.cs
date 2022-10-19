using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class NumberColorMapper
    {
        private static NumberColorMapper sInstance;

        public static NumberColorMapper getInstance()
        {
            if (sInstance == null)
            {
                sInstance = new NumberColorMapper();
            }
            return sInstance;
        }

        public Color MapNumberToColor(int number)
        {
            Color color;
            switch (number)
            {
                case 1:
                    color = Color.FromArgb(0, 0, 255);
                    break;
                case 2:
                    color = Color.FromArgb(0, 123, 0);
                    break;
                case 3:
                    color = Color.FromArgb(255, 0, 0);
                    break;
                case 4:
                    color = Color.FromArgb(0, 0, 123);
                    break;
                case 5:
                    color = Color.FromArgb(123, 0, 0);
                    break;
                case 6:
                    color = Color.FromArgb(0, 123, 123);
                    break;
                case 7:
                    color = Color.FromArgb(0, 0, 0);
                    break;
                case 8:
                    color = Color.FromArgb(123, 123, 123);
                    break;
                default:
                    throw new ArgumentException("El numero no puede ser menor que cero ni mayor a 8");
            }
            return color;
        }

    }
}
