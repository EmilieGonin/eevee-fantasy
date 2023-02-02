using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{

    internal class MapEnd : Map
    {

        public MapEnd()
        {
            X = 10;
            Y = 8;

            //Histories = new string[]
            //{
            //    ("Thank you for playing our game till the end!"),
            //    ("We, Tom Le Gros, Emilie Gonin and Jimmy Dutto, can't thank you enough."),
            //    ("We have put a lot of effort in the last 2 weeks to make this game."),
            //    ("We hope it was enjoyale, and wish you the best!"),
            //    ("We hope to see you playing other games from our ever growing company..."),
            //    ("FrownGate"),
            //    ("See you soon!")
            //};

            MapLink = "EndScreen.txt";
            CreateMap();


        }
    }
}

