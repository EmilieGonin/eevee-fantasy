using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{

    internal class MapZero : Map
	{



        public MapZero()
        {
            MapLink = "Map_Basic.txt";

            //DrawMap("Map_Basic.txt");
            
        }
    }
}