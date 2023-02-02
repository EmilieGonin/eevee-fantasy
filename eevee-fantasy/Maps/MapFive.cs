using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{

    internal class MapFive : Map
    {

        public MapFive()
        {
            X = 3;
            Y = 18;

            //X_Pre = 62;
            //Y_Pre = 19;
            levelCap = 80;
            Friend_Id = 5;
            Enemy_Id = 5;

            MapLink = "LevelFive.txt";
            CreateMap();


        }
    }
}

