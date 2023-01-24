using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class AttPotion : Inventory
    {
        int _Attack = 100;
        int _attpotionprice = 70;

        public int Attpotionprice { get => _attpotionprice; set => _attpotionprice = value; }
        public int Attack { get => _Attack; set => _Attack = value; }

        void Use(Character eevee)
        {
            //eevee.setAtt() += Attack;
        }
    }
}

