using System;
namespace eevee_fantasy
{
	internal class MapFour : Map
	{
        public MapFour()
        {
            X = 72;
            Y = 14;

            X_Pre = 2;
            Y_Pre = 2;

            X_PreJolt = 20;
            Y_PreJolt = 11;

            Enemy_Id = 3;
            levelCap = 40;

            MapLink = "LevelFour.txt";
            CreateMap();


        }
    }
}

