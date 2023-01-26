using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{
    public class Skill
    {
        readonly int _accuracy;

        //public int Id { get; protected set; }
        public string? Name { get; protected set; }
        public int Damage { get; protected set; }
        public int PP { get; set; }

        public Skill()
        {
            _accuracy = 95;
            PP = 35;
        }

        public virtual void Use(Attribute attribute, Character target)
        {
            PP -= 1;
            //add accuracy check
            int damage = Convert.ToInt32(Damage * attribute.EffectivenessMultiplier(attribute, target.Attribute)) - target.TotalDef / 2;
            target.LooseHp(damage);
        }
    }
}
