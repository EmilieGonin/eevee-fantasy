using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy.Maps
{

    public class MapSymbols
	{
        public static MapSymbols[,] map = new MapSymbols[32, 128];
        public char character { get; set; }
        public ConsoleColor colour { get; set; }

        public static void Main()
        {

            MapSymbols grass = new MapSymbols();
            grass.character = '#';
            grass.colour = ConsoleColor.Green;

            StreamReader mapzero = new StreamReader("Map_Basic.txt");

            string lines;

            while ((lines = mapzero.ReadLine()) != null)
            {
                Console.WriteLine(lines);

            }
        }

    }
}

