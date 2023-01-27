using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class SkillFlamethrower : Skill
    {
        public SkillFlamethrower()
        {
            Name = "Flamethrower";
            Damage = 90;
            PP = 15;
        }
    }
}
