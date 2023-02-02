using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class Eevee : Character
    {
        public Eevee()
        {

            Id = 0;
            //stats

            

            Name = "Eevee";
            BaseHp = 55;
            BaseDef = 50;
            BaseAtk = 70;
            Speed = 110;

            //state
            Recruited = true;
            Alive = true;
            Attribute = new Normal();

            //graphic
            Sprite = 'E';
            Color = ConsoleColor.Magenta;

            
            for (int i = 0; i < 1001; i++)
            {
                LevelUp();
            }

            TotalXP = lvl * lvl * lvl;
            XPToGet = (lvl + 1) * (lvl + 1) * (lvl + 1);
            

      


        


        }



    }
}
