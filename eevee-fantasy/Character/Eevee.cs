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
            Name = "Eevee";
            BattleHp = TotalHp = 110;
            TotalDef = 76;
            TotalAtk = 40;
            Speed = 110;

            for (int i = 0; i < 40; i++)
            {
                LevelUp();
            }

            TotalXP = lvl * lvl * lvl;
            XPToGet = (lvl + 1) * (lvl + 1) * (lvl + 1);
            

            Alive = true;
            Recruited = true;

            Attribute = new Fire();
            UnlockSkills();
           

        }



    }
}
