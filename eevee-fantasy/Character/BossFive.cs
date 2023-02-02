using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class BossFive : BossEnemy
    {
        public BossFive()
        {
            Id = 5;

            Enemy = 'B';
            Color = ConsoleColor.DarkRed;
            XpGain = 700;
            X = 51;
            Y = 5;
        }
    }
}

