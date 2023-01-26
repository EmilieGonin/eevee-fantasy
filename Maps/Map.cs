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
        public string? MapLink { get; set; }

        public void DrawMap()
        {
            //Console.Clear();

            using (StreamReader maps = new StreamReader(MapLink))
            {
                string mapContent = maps.ReadToEnd(); //21x75
                //Console.WriteLine(mapContent);
                string[] rows = mapContent.Split("\r\n");
                foreach (var row in rows)
                {
                    //Console.WriteLine(row);
                    //col2.AddRange(row.Split(" "));

                }
                int rowLength = rows[0].Length; //75
                //Console.WriteLine(rowLength);
                int rowCount = rows.Length; //21
                //Console.WriteLine(rowCount);
                char[,] map = new char[rowCount, rowLength];

                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < rowLength; j++)
                    {
                        map[i, j] = rows[i][j];
                        if (map[i, j] == '#')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (map[i, j] == '/')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        else if (map[i, j] == '*')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }
                        else if (map[i, j] == '.')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
            }

        }

    }
} 