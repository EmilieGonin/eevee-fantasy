using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Revive : Inventory
    {
        
        int _reviveprice = 70;

        public int Reviveprice { get => _reviveprice; set => _reviveprice = value; }

        void Use(Character eevee)
        {
            //eevee.setAlive() = true;
        }
    }
}

