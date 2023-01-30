using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{

    internal class MapOne : Map
    {

        public MapOne()
        {
            X = 34;
            Y = 18;

            MapLink = "LevelOne.txt";
            CreateMap();


        }
    }
}

