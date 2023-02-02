using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public static class Bosses
    {
        public static List<BossEnemy>? BossesToBeat;

        public static void Init()
        {
            BossesToBeat = new List<BossEnemy> { new BossOne(), new BossTwo(), new BossThree(), new BossFour(), new BossFive() };
        }
    }
}

