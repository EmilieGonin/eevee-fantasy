using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Fire : Attribute
    {
        public Fire()
        {
            Id = 2;
            SpecialAttackOne = new Skill(1, "Ember", 0, 0);
            SpecialAttackTwo = new Skill(2, "Flamethrower", 0, 0);
            SpecialAttackThree = new Skill(3, "Fire Blast", 0, 0);
            Strengths = new int[] { 5, 6 };
            Weaknesses = new int[] { 3 };
        }
    }
}
