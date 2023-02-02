using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class Normal : Attribute
    {
        public Skill? NormalAttack { get; set; }
        public Normal()
        {
                
            Id = 1;
            SpecialAttacks = new Skill[] { new SkillPound(), new SkillTakeDown(), new SkillDoubleEdge() };
            NormalAttack = new SkillTackle();
        }
    }
}
