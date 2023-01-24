using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class HyperPotion : Inventory
    {
        int _health = 200;
        int _hyperpotionprice = 100; 

        public int Hyperpotionprice { get => _hyperpotionprice; set => _hyperpotionprice = value; }
        public int Health { get => _health; set => _health = value; }

        void Use(Character eevee)
        {
            //eevee.setHp() += Health;
        }
    }
}


