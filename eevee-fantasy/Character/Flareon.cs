using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Flareon : Character
    {

        public Flareon()
        {
            Sprite = 'F';
            Color = ConsoleColor.Red;
            Id = 1;

            X = 5;
            Y = 18;


            //stats
            Name = "Flareon";
            BaseHp = 65;
            BaseDef = 60;
            BaseAtk = 130;
            Speed = 110;

            //state

            Alive = true;
            Attribute = new Fire();

            for (int i = 0; i < 10; i++)
            {
                LevelUp();
            }

            TotalXP = lvl * lvl * lvl;
            XPToGet = (lvl + 1) * (lvl + 1) * (lvl + 1);
        }

    }
}
