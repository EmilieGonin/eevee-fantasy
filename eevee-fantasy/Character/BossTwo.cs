using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class BossTwo : BossEnemy
    {
        public BossTwo()
        {
            Id = 2;
            Attribute = new Water();
            Enemy = 'B';
            Color = ConsoleColor.DarkBlue;
            XpGain = 550;
            X = 61;
            Y = 13;

            BaseHp = 75;
            BaseDef = 50;
            BaseAtk = 60;
            Speed = 100; // random 100 -> 110;
            for (int i = 0; i < 35; i++)
            {
                LevelUp();
            }

            BossDialog = new string[]
            {
                ("BRRRRHGGH!!!"),
                ("My Master told me to kill you...")
            };

        }
    }
}

