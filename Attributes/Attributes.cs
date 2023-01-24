using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Attributes
    {
        public int Id { get; protected set; }
        public Skill SpecialAttackOne { get; protected set; }
        public Skill SpecialAttackTwo { get; protected set; }
        public Skill SpecialAttackThree { get; protected set; }
        public int[]? Strengths { get; protected set; }
        public int[]? Weaknesses { get; protected set; }

        //1 = Normal, 2 = Fire, 3 = Water
        //4 = Thunder, 5 = Plant, 6 = Ice
        //Création d'un enum ?
        public void CheckEffectiveness(Attribute attack, Attribute defense)
        {
            //
        }
    }
}
