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
            BaseHp = 60;
            BaseDef = 50;
            BaseAtk = 60;
            Speed = 100; // random 100 -> 110;
            for (int i = 0; i < 50; i++)
            {
                LevelUp();
            }

            BossDialog = new string[]
            {
                ("BRRRRHGGH!!!"),
                ("You will not make it out alive!")
            };

        }
    }
}

