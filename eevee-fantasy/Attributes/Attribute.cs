using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class Attribute
    {
        public int Id { get; protected set; }
        public Skill[]? SpecialAttacks { get; protected set; }
       
        public int[]? Strengths { get; set; }
        public int[]? Weaknesses { get; set; }

        //1 = Normal, 2 = Fire, 3 = Water
        //4 = Thunder, 5 = Plant, 6 = Ice

        //Création d'un enum ?
        public bool isEffective(Attribute defenser)

        {
            if (Strengths != null && Strengths.Contains(defenser.Id))
            {
                //Console.WriteLine("Super effective");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isWeak(Attribute defenser)
        {
            if (Weaknesses != null && Weaknesses.Contains(defenser.Id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public float EffectivenessMultiplier(Attribute attack, Attribute defense)
        {
            if (isEffective(defense))
            {
                return (float)1.5;
            }
            else if (isWeak(defense)) {
                return (float)0.5;
            }
            else
            {
                return 1;
            }
        }
    }
}
