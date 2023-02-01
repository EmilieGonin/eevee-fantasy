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

            X_Pre = 61;
            Y_Pre = 18;

            Friend_Id = 4;
            Enemy_Id = 2;

            MapLink = "LevelTwo.txt";
            CreateMap();


        }
    }
}

