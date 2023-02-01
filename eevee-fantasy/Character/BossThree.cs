using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class BossThree : Character
    {
        public BossThree()
        {
            Id = 3;

            Enemy = 'B';
            Color = ConsoleColor.DarkRed;

            X = 3;
            Y = 14;
        }
    }
}

