using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class BattleMap : Map
    {
        public BattleMap()
        {
            MapLink = "Battle.txt";
            CreateMap();
        }
    }
}
