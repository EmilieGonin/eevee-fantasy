using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Normal : Attribute
    {
        public Normal()
        {
            Id = 1;
            SpecialAttackOne = new Skill(1, "Tackle", 0, 0);
            SpecialAttackTwo = new Skill(2, "Take Down", 0, 0);
            SpecialAttackThree = new Skill(3, "Giga Impact", 0, 0);
        }
    }
}
