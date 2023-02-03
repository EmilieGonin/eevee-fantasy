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
        protected int _accuracy { get; set;  }

        //public int Id { get; protected set; }
        public string? Name { get; protected set; }
        public int Damage { get; protected set; }
        public int PP { get; set; }

        public Skill()
        {
            _accuracy = 95;
            PP = 35;
        }

        public virtual void Use(Character attacker, Character target)
        {
            PP -= 1;
            //add accuracy check
            int damage = Convert.ToInt32((((attacker.lvl * 0.4 + 2) * Damage * attacker.TotalAtk) / (target.TotalDef * 1 * 50)) * attacker?.Attribute!.EffectivenessMultiplier(attacker.Attribute, target.Attribute!));
            //Console.WriteLine("Damage done " + damage);
            Random rnd = new Random();
            if(rnd.Next(0,100) >= _accuracy)
            {
                new Dialogue("Missed");
            }
            else
            {
                if (attacker.Name != null)
                {
                    new Dialogue("You dealed " + damage + " damage");

                }
                target.LooseHp(damage);
            }

            
            //Console.WriteLine("Remaining HP : " + target.BattleHp);
        }
    }
}
