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
            X = 33;
            Y = 18;
            X_Pre = 71;
            Y_Pre = 8;
            levelCap = 10;
            Friend_Id = 1;

            Enemy_Id = 1;

            MapLink = "LevelOne.txt";
            CreateMap();


        }
    }
}

