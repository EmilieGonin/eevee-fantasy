using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{
    internal class MapOne : Map
    {
        public MapOne()
        {
            X = 33;
            Y = 18;
            X_Pre = 71;
            Y_Pre = 8;
            levelCap = 10;
            Friend_Id = 1;

            Enemy_Id = 0;

            Histories = new string[]
            {
                ("OMG! it's so dark!"),
                ("I shouldn't have entered, I'm too weak, I'm only an Eevee"),
                ("How am I supposed to save my friends when I can barely save myself."),
                ("..."),
                ("Oh look! there's tall grass everywhere! let's go train there"),
                ("Maybe with enough training we can save my friends!"),
                ("MWUAHAHAHAHA!!!..."),
                ("Yes Eevee, you are weak and..."),
                ("(someone is talking in the background)"),
                ("WHATT!!? "),
               ("Eevee's friends have escaped and are now dispersed in the dungeon!"),
                ("Wait, oh no, I am still on the radio!"),
                ("urghm, uhm you didn't hear any of that did you?"),
                ("A-a-anyways, as I was saying..."),
                ("Even with training you will never be able to get out of this dungeon"),
                ("The bosses guarding the exits will squash you like an Oran berry"),
                ("MWUAHAHAHAAA!!!..."),
                ("Well, we can't know that until we try! Let's go!")
            };

            MapLink = "LevelOne.txt";
            CreateMap();
        }
    }
}

