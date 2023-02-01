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
            Id_Friend = 4;
            X = 54;
            Y = 3;


            //stats
            Name = "Leafeon";
            BaseHp = 65;
            BaseDef = 130;
            BaseAtk = 110;
            Speed = 95;

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
