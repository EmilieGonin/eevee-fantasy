using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class Fire : Attribute
    {
        public Fire()
        {
            Id = 2;
            SpecialAttacks = new Skill[] { new SkillEmber(), new SkillFlamethrower(), new SkillFireBlast() };
            Strengths = new int[] { 5, 6 };
            Weaknesses = new int[] { 3 };
        }
    }
}
