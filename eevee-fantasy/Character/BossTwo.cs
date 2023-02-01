using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class BossTwo : Character
    {
        public BossTwo()
        {
            Id = 2;

            Enemy = 'B';
            Color = ConsoleColor.DarkRed;

            X = 61;
            Y = 13;
        }
    }
}

