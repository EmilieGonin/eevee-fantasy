using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
	internal class Potion : Inventory
	{
		int _health = 40;
		int _potionprice = 10;
		
        public int Potionprice { get => _potionprice; set => _potionprice = value; }
        public int Health { get => _health; set => _health = value; }

        void Use(Character eevee)
		{
			//eevee.setHp() += Health;
		}

		
    }
}

