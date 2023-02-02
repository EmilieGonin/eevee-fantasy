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
            Enemy_Id = 4;

            //Histories = new string[]
            //{
            //    ("WHAATTT!!?"),
            //    ("How did you make it to level 5!"),
            //    ("I must have miss calculated something in my plans..."),
            //    ("urgh, well no worries, we'll initiate plan b"),
            //    ("Now you have no chance of getting out alive!"),
            //    ("The dungeon's exit will be destroyed in 10 minutes!"),
            //    ("You won't have time to beat the last boss before then"),
            //    ("You will be trapped here for ever!"),
            //    ("MUAHAHAHAH!!!... I'm a genius"),
            //    ("Oh no!, did you here that?"),
            //    ("This monster is planning to destroy the exit!"),
            //    ("We have to get ready for the final boss and get out of here!")
            //};

            MapLink = "LevelFive.txt";
            CreateMap();
        }
    }
}

