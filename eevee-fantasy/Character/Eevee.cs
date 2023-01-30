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

            lvl = 5;
            TotalHp = 300;
            TotalDef = 76;
            TotalAtk = 50;
            Speed = 110;

            for(int i = 0;i < lvl; i++) 
            {
                LevelUp();
            }
            TotalXP = lvl * lvl * lvl;
            XPToGet = (lvl + 1) * (lvl + 1) * (lvl + 1);


           
            Recruited = true;

           Attribute = new Normal();
            UnlockSkills();
           
        }
       
        
        
    }
}
