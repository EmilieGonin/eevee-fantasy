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

            BossDialog = new string[]
            {
                ("BRRRRHGGH!!!"),
                ("My Master told me to kill you...")
            };
        }
    }
}

