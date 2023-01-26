using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Revive : Inventory
    {
        public Revive()
        {
            Id = 6;
            Price = 70;
        }

        void Use(Character character)
        {
            //character.Alive = true;
        }
    }
}

