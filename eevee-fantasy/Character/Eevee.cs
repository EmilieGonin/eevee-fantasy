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
            TotalHp = 300;
            TotalDef = 76;
            TotalAtk = 50;
            Speed = 110;
            Recruited = true;

            for (int i = 0;i < 5; i++) 
            {
                LevelUp();
            }

            Attribute = new Normal();
        }
       
        
        
    }
}
