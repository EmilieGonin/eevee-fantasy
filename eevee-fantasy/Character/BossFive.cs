using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class BossFive : Character
    {
        public BossFive()
        {
            Id_Enemy = 5;

            Enemy = 'B';
            Color = ConsoleColor.DarkRed;

            X = 51;
            Y = 5;
        }
    }
}

