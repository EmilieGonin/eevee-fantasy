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
        public int Id { get; protected set; }
        public string? Name { get; protected set; }
        public int Damage { get; protected set; }
        public int PP { get; protected set; }
        public int Accuracy { get; protected set; }

        public Skill(int id, string? name, int damage, int pp)
        {
            Id = id;
            Name = name;
            Damage = damage;
            PP = pp;
            Accuracy = 95;
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
