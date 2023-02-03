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


            BaseHp = 60;
            BaseDef = 50;
            BaseAtk = 70;
            Speed = 100; // random 100 -> 110;
            for (int i = 0; i < 45; i++)
            {
                LevelUp();
            }
            BossDialog = new string[]
            {
                ("BRRRRHGGH!!!"),
                ("You look so weak!")
            };

        }
    }
}

