using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Attribute
    {
        public int Id { get; protected set; }
        public Skill SpecialAttackOne { get; protected set; }
        public Skill SpecialAttackTwo { get; protected set; }
        public Skill SpecialAttackThree { get; protected set; }
        protected int[]? Strengths { get; set; }
        protected int[]? Weaknesses { get; set; }

        //1 = Normal, 2 = Fire, 3 = Water
        //4 = Thunder, 5 = Plant, 6 = Ice
        //Création d'un enum ?
        public bool isEffective(Attribute attack, Attribute defense)
        {
            if (attack.Strengths != null && attack.Strengths.Contains(defense.Id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isWeakness(Attribute attack, Attribute defense)
        {
            if (attack.Weaknesses != null && attack.Weaknesses.Contains(defense.Id))
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
            if (isEffective(attack, defense))
            {
                return (float)1.5;
            }
            else if (isWeakness(attack, defense)) {
                return (float)0.5;
            }
            else
            {
                return 1;
            }
        }
    }
}
