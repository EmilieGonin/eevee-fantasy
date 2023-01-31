using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class AtkPotion : Item
    {
        readonly int _attack;

        public AtkPotion()
        {
            Name = "Attack Potion";
            Price = 70;
            _attack = 100;
        }

        public override void Use(Character character)
        {
            base.Use(character);
            character.TotalAtk += _attack;
        }
    }
}

