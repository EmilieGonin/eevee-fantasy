using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
	internal class Potion : Inventory
	{
        protected int Health { get; set; }

        public Potion()
		{
			Id = 1;
			Price = 10;
            Health = 40;
		}

        public void Use(Character character)
		{
			//character.Hp += Health;
		}

		
    }
}

