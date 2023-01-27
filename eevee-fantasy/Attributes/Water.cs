using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Water : Attribute
    {
        public Water()
        {
            Id = 3;
            SpecialAttacks = new Skill[] { new SkillBubbleBeam(), new SkillWaterGun(), new SkillHydroPulse() };
            Strengths = new int[] { 2 };
            Weaknesses = new int[] { 4, 5, 6 };
        }
    }
}
