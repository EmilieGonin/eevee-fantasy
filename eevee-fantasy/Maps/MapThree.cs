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

            X_Pre = 3;
            Y_Pre = 14;
            levelCap = 30;
            Friend_Id = 2;
            Enemy_Id = 2;

            //Histories = new string[]
            //{
            //    ("MWUAHAHAHAH!!!..."),
            //    ("Well, well, well"),
            //    ("Look who's made it to level 3!"),
            //    ("Unfortunately for you, it only gets harder from here!"),
            //    ("You will soon see the limit of your powers"),
            //    ("MWUAHAHAHAHA!!!..."),
            //    ("*yawn* Yeah whatever man we're strolling this dungeon!"),
            //    ("We'll be out in no time!")
            //};

            MapLink = "LevelThree.txt";
            CreateMap();
        }
    }
}

