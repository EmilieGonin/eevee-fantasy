



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eevee_fantasy;
using static System.Net.Mime.MediaTypeNames;




namespace eevee_fantasy
{

    public class Program
    {



        public static void Main()
        {

            MapZero mapZero = new MapZero(); 
            mapZero.DrawMap();

        }
    }
}

//Console.WriteLine("Hello, World!");
//Settings game = new Settings();
//Character character = new Character();
Character character = new Character();
Game.Init();