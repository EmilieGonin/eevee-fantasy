using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{

    internal class MapThree : Map
    {

        public MapThree()
        {
            X = 62;
            Y = 3;

            Friend_Id = 2;

            MapLink = "LevelThree.txt";
            CreateMap();


        }
    }
}

