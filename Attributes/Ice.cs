using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Ice : Attributes
    {
        public Ice()
        {
            Id = 6;
            SpecialAttackOne = new Skill(1, "", 0, 0);
            SpecialAttackTwo = new Skill(2, "", 0, 0);
            SpecialAttackThree = new Skill(3, "", 0, 0);
            Strengths = new int[] { 3, 5 };
            Weaknesses = new int[] { 2 };
        }
    }
}
