using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
	public class BossOne : BossEnemy
    {
		public BossOne()
		{
			Id = 1;
			Attribute = new Plant();
			Enemy = 'B';
			Color = ConsoleColor.DarkGreen;
            XpGain = 500;
            X = 62;
            Y = 8;

            BossDialog = new string[]
            {
                ("BRRRRHGGH!!!"),
                ("You will perish!")
            };

            BaseHp = 60;
            BaseDef = 50;
            BaseAtk = 60;
            Speed = 100; // random 100 -> 110;
            for (int i = 0; i < 25; i++)
            {
                LevelUp();
            }

        }
	}
}

