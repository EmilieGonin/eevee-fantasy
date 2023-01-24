using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Water : Attributes
    {
        public Water()
        {
            Id = 3;
            SpecialAttackOne = new Skill(1, "Bubble Beam", 0, 0);
            SpecialAttackTwo = new Skill(2, "Water Gun", 0, 0);
            SpecialAttackThree = new Skill(3, "Hydro Pulse", 0, 0);
            Strengths = new int[] { 2 };
            Weaknesses = new int[] { 4, 5, 6 };
        }
    }
}
