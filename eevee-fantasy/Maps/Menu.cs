using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Menu : Map
    {
        public Menu()
        {
            MapLink = "Inventory.txt";
            CreateMap();
        }
    }
}
