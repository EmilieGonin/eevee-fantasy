using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class SkillDoubleEdge : Skill
    {
        public SkillDoubleEdge()
        {
            Name = "Double-Edge";
            Damage = 120;
            PP = 15;
        }

        public override void Use(Attribute attribute, Character target)
        {
            base.Use(attribute, target);
            //Attacker receveid 1/3 dmg
        }
    }
}
