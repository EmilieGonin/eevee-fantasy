using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Glaceon : Character
    {
        public Glaceon()
        {

            Sprite = 'G';
            Color = ConsoleColor.Cyan;
            Id_Friend = 5;
            X = 37;
            Y = 9;

            //stats
            Name = "Glaceon";
            BaseHp = 65;
            BaseDef = 110;
            BaseAtk = 80;
            Speed = 100;

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
