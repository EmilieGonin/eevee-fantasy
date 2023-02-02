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

            //Histories = new string[]
            //{
            //    ("hmmmmm..."),
            //    ("It's wierd, he's not talking although we've made it to level 4"),
            //    ("Guess he must be busy or died in his chair"),
            //    (" Well let's focus on what's ahead of us!")
            //};

            MapLink = "LevelFour.txt";
            CreateMap();
        }
    }
}

