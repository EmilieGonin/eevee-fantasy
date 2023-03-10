using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Leafeon : Character
    {
        public Leafeon()
        {
            Sprite = 'L';
            Color = ConsoleColor.Green;
             Id = 4;
            X = 54;
            Y = 3;

            //stats
            Name = "Leafeon";
            BaseHp = 65;
            BaseDef = 130;
            BaseAtk = 110;
            Speed = 95;

            //state
            Alive = true;
            Attribute = new Plant();

            for (int i = 0; i < 12; i++)
            {
                LevelUp();
            }

            TotalXP = lvl * lvl * lvl;
            XPToGet = (lvl + 1) * (lvl + 1) * (lvl + 1);
        }
    }
}
