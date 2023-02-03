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
            _accuracy = 30;
            Damage = 0;
            PP = 5;
        }

        public override void Use(Character attacker, Character target)
        {
           
            //30 + UserLevel - TargetLevel
            //20 if Ice
            Random rnd = new Random();
            if (rnd.Next(0, 100) <= _accuracy)
            {
                if (target is not BossEnemy) 
                {
                    new Dialogue("It's a oneshot");
                    target.LooseHp(target.TotalHp);
                }
                else { base.Use(attacker, target); }

            }
            else
            {
                new Dialogue("Missed");
            }

        }
    }
}
