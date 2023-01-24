using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class AtkPotion : Inventory
    {
        readonly int _attack;

        public AtkPotion()
        {
            Id = 4;
            Price = 70;
            _attack = 100;
        }

        void Use(Character character)
        {
            //character.Atk += _attack;
        }
    }
}

