using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Revive : Item
    {
        public Revive()
        {
            Price = 70;
        }

        public override void Use(Character character)
        {
            base.Use(character);
            character.Alive = true;
        }
    }
}

