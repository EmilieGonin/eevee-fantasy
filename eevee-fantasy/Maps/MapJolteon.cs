using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{
    internal class MapJolteon : Map
    {
        public MapJolteon()
        {
            X = 17;
            Y = 11;

            Friend_Id = 3;

            MapLink = "LevelJolteon.txt";
            CreateMap();
        }
    }
}

