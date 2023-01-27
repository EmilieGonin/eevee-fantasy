using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Ice : Attribute
    {
        public Ice()
        {
            Id = 6;
            SpecialAttacks = new Skill[] { new SkillIceShard(), new SkillIceBeam(), new SkillSheerCold() };
            Strengths = new int[] { 3, 5 };
            Weaknesses = new int[] { 2 };
        }
    }
}
