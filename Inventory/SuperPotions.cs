using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
	internal class SuperPotion : Inventory
	{
		int _health = 100;
		int _superpotionprice = 50;

        public int Superpotionprice { get => _superpotionprice; set => _superpotionprice = value; }
        public int Health { get => _health; set => _health = value; }

        void Use(Character eevee)
		{
            //eevee.setHp() += Health;
        }
    }
}

