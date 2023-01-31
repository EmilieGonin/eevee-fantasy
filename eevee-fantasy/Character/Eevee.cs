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
            Id= 0;
            Name = "Eevee";
            BattleHp = TotalHp = 110;
            TotalDef = 40;
            TotalAtk = 76;
            Speed = 110;
            Recruited = true;

            Attribute = new Fire();
            Sprite = 'E';
            Color = ConsoleColor.Magenta;


            for (int i = 0; i < 40; i++)
            {
                LevelUp();
            }

            TotalXP = lvl * lvl * lvl;
            XPToGet = (lvl + 1) * (lvl + 1) * (lvl + 1);
            

            Alive = true;
            Recruited = true;

        


        }



    }
}
