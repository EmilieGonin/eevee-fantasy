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

            X_PreJolt = 19;
            Y_PreJolt = 11;

            MapLink = "LevelFour.txt";
            CreateMap();


        }
    }
}

