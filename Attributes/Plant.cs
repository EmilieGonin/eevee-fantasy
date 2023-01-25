using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Plant : Attribute
    {
        public Plant()
        {
            Id = 5;
            SpecialAttackOne = new Skill(1, "Vine Whip", 0, 0);
            SpecialAttackTwo = new Skill(2, "Leaf Blade", 0, 0);
            SpecialAttackThree = new Skill(3, "Power Whip", 0, 0);
            Strengths = new int[] { 3 };
            Weaknesses = new int[] { 2, 6 };
        }
    }
}
