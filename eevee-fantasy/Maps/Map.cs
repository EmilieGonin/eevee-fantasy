using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Map
    {

        public char[,]? myMap { get; set; }
        public string? MapLink { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void CreateMap()
        {
            var directory = "../../../res/" + MapLink;

            using (StreamReader maps = new StreamReader(directory))
            {
                string mapContent = maps.ReadToEnd(); //21x75
                string[] rows = mapContent.Split('\n');

                int rowLength = rows[0].Length - 1; //75
                int rowCount = rows.Length; //21
                myMap = new char[rowCount, rowLength];

                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < rowLength; j++)
                    {
                        myMap[i, j] = rows[i][j];
                    }
                }
            }

            
        }
        public void DrawMap()
        {
            Console.SetCursorPosition(0,0);

            for (int i = 0; i < myMap.GetLength(0); i++)
            {
                for (int j = 0; j < myMap.GetLength(1); j++)
                {
                    char item = myMap[i, j];

                    switch (item)
                    {
                        case '#':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case '\\':
                        case '/':
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            break;
                        case '*':
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        case '.':
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case '-':
                        case '+':
                        case '|':
                        case '~':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '{':
                        case '}':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }                
                    
                    Console.Write(item);
                }
                Console.WriteLine();
            }

        }

        public bool Collisions(int eeveeX, int eeveeY)
        {
            switch(myMap[eeveeY, eeveeX])
            {
                case '/':
                    return true;
                case '\\':
                    return true;
                case '-':
                    return true;
                case '|':
                    return true;
                case '+':
                    return true;
            }
            return false;
        }

        public bool Tp(int eeveeX, int eeveeY)
        {

            switch(myMap[eeveeY, eeveeX])
            {
                case '>':
                case '<':
                case 'v':
                    Game.GameLevel += 1;
                    return true;
                case '^':
                    Game.GameLevel -= 1;
                    return true;
            }

            return false;
        }
    }

}