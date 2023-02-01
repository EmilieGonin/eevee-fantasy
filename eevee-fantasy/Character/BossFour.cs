using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class BossFour : Character
    {
        public BossFour()
        {
            Id_Enemy = 4;

            Enemy = 'B';
            Color = ConsoleColor.DarkRed;

            X = 2;
            Y = 3;
        }
    }
}

