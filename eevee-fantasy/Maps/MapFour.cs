using System;
namespace eevee_fantasy
{
	internal class MapFour : Map
	{
        public MapFour()
        {
            X = 72;
            Y = 14;

            X_Pre = 3;
            Y_Pre = 3;

            MapLink = "LevelFour.txt";
            CreateMap();


        }
    }
}

