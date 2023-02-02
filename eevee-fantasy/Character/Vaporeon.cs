using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Vaporeon : Character
    {

         
        public Vaporeon()
        {
            Sprite = 'V';
            Color = ConsoleColor.Blue;
             Id = 2;
            X = 73;
            Y = 12;

            //stats
            Name = "Vaporoen";
            BaseHp = 130;
            BaseDef = 60;
            BaseAtk = 90;
            Speed = 90;

            //state
           
            Alive = true;
            Attribute = new Fire();

            for (int i = 0; i < 20; i++)
            {
                LevelUp();
            }

            TotalXP = lvl * lvl * lvl;
            XPToGet = (lvl + 1) * (lvl + 1) * (lvl + 1);

        }
    }
}
