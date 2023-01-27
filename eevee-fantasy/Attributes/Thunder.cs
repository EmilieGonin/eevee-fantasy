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
            SpecialAttacks = new Skill[] { new SkillSpark(), new SkillThunderbolt(), new SkillThunder() };
            Strengths = new int[] { 3 };
        }
    }
}
