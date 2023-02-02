using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class BossFour : BossEnemy
    {
        public BossFour()
        {
            Id = 4;

            Enemy = 'B';
            Color = ConsoleColor.DarkRed;
            XpGain = 650;
            X = 2;
            Y = 3;
        }
    }
}

