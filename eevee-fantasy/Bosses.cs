using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public static class Bosses
    {
        public static List<Character>? BossesToBeat;

        public static void Dead(BossEnemy bossenemies)
        {
            BossesToBeat = new List<Character> { bossenemies, new BossOne(), new BossTwo(), new BossThree(), new BossFour(), new BossFive() };
        }
    }
}

