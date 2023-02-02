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

        public static void Init()
        {
            BossesToBeat = new List<Character> { new BossOne(), new BossTwo(), new BossThree(), new BossFour(), new BossFive() };
        }
    }
}

