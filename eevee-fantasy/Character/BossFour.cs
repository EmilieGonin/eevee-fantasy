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
            //give random type according to pokemons levels
            Enemy = 'B';
            Color = ConsoleColor.DarkRed;
            XpGain = 650;
            X = 2;
            Y = 3;

            BossDialog = new string[]
            {
                ("BRRRRHGGH!!!"),
                ("I can't let you pass!")
            };
        }
    }
}

