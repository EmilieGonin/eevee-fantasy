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
            SpecialAttacks = new Skill[] { new SkillVineWhip(), new SkillLeafBlade(), new SkillPowerWhip() };
            Strengths = new int[] { 3 };
            Weaknesses = new int[] { 2, 6 };
        }
    }
}
