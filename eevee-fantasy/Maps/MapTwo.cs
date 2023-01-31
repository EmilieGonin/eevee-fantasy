using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{

    internal class MapTwo : Map
    {

        public MapTwo()
        {
            X = 3;
            Y = 8;

            MapLink = "LevelTwo.txt";
            CreateMap();


        }
    }
}

