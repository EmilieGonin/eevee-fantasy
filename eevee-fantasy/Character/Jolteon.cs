using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Jolteon : Character
    {

        public Jolteon()
        {
            Sprite = 'J';
            Color = ConsoleColor.Yellow;
            Id = 3;
            X = 0;
            Y = 0;

            //stats
            Name = "Jolteon";
            BaseHp = 65;
            BaseDef = 60;
            BaseAtk = 100;
            Speed = 140;

            //state
            Recruited = true;
            Alive = true;
            Attribute = new Fire();

            for (int i = 0; i < 40; i++)
            {
                LevelUp();
            }

            TotalXP = lvl * lvl * lvl;
            XPToGet = (lvl + 1) * (lvl + 1) * (lvl + 1);

        }
    }
}
