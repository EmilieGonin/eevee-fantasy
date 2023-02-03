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
            Id  = 3;
            X = 6;
            Y = 11;

            //stats
            Name = "Jolteon";
            BaseHp = 65;
            BaseDef = 60;
            BaseAtk = 100;
            Speed = 140;

            //state
            Alive = true;
            Attribute = new Thunder();

            for (int i = 0; i < 25; i++)
            {
                LevelUp();
            }

            TotalXP = lvl * lvl * lvl;
            XPToGet = (lvl + 1) * (lvl + 1) * (lvl + 1);
        }
    }
}
