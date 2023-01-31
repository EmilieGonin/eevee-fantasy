using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class SkillSheerCold : Skill
    {
        public SkillSheerCold()
        {
            Name = "Sheer Cold";
            Damage = 0;
            PP = 5;
        }

        public override void Use(Character attacker, Character target)
        {
            //30 + UserLevel - TargetLevel
            //20 if Ice
            target.BattleHp = 0;
        }
    }
}
