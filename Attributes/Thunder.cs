using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Thunder : Attribute
    {
        public Thunder()
        {
            Id = 4;
            SpecialAttackOne = new Skill(1, "Spark", 0, 0);
            SpecialAttackTwo = new Skill(2, "Tunderbolt", 0, 0);
            SpecialAttackThree = new Skill(3, "Thunder", 0, 0);
            Strengths = new int[] { 3 };
        }
    }
}
