using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{

    internal class MapZero2 : Map
    {

        public MapZero2()
        {
            X = 35;
            Y = 14;

            //Histories = new string[]
            //{
            //    ("BRRGGHJGGH!"),
            //    ("(The cave entranced collapsed behind you)"),
            //    ("Whew! Just in time!"),
            //    ("NOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!..."),
            //    ("My plans have failed..."),
            //    ("I underestimated you Eevee, but it won't happen again..."),
            //    ("Until next time!"),
            //    ("MWUAHAHAHHAHA!!!... *cough* *cough* *cough* ... I hate old age."),
            //    ("Well, it looks like he's gone, thank you so much for coming with me,"),
            //    ("risking your life to save my friends, I truely can't thank you enough."),
            //    ("Let's head down the mountain and go home!")

            //};

            MapLink = "Map_Basic_End.txt";
            CreateMap();


        }
    }
}
