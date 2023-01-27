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


        public void CreateMap()
        {
            var directory = "../../../res/" + MapLink;

            using (StreamReader maps = new StreamReader(directory))
            {
                string mapContent = maps.ReadToEnd(); //21x75
                string[] rows = mapContent.Split("\r\n");

                int rowLength = rows[0].Length; //75
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
            foreach (var item in myMap)
            {
                if (item == '#')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (item == '/')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                else if (item == '*')
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                else if (item == '.')
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else if (item == '\\')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(item);
            }
            
        }
    }

}