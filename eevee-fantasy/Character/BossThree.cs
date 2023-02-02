using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class BossThree : BossEnemy
    {
        public BossThree()
        {
            Id = 3;
            Attribute = new Fire();
            Enemy = 'B';
            Color = ConsoleColor.DarkRed;
            XpGain = 600;
            X = 3;
            Y = 14;
        }
    }
}

