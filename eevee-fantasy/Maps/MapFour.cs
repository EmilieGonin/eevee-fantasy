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
            levelCap = 40;
            Enemy_Id = 4;

            MapLink = "LevelFour.txt";
            CreateMap();


        }
    }
}

