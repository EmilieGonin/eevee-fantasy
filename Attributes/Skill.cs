using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Skill
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

        public virtual void Use(Character target)
        {
            //target.Hp -= Damage;
        }
    }
}
