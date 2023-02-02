using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class Map
    {
        private static int _cursorY;
        public char[,]? myMap { get; set; }
        public string? MapLink { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int X_Pre { get; set; }
        public int Y_Pre { get; set; }
        public int DrawY { get; set; }
        public int X_PreJolt { get; set; }
        public int Y_PreJolt { get; set; }
        public int levelCap { get; set; }
        public int Friend_Id { get; set; }
        public int Enemy_Id { get; set; }

        public Map()
        {
            DrawY = 0;
            Enemy_Id = -1;
        }

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
        public virtual void DrawMap()
        {
            Console.SetCursorPosition(0, DrawY);

            for (int i = 0; i < myMap.GetLength(0); i++)
            {
                for (int j = 0; j < myMap.GetLength(1); j++)
                {
                    char item = myMap[i, j];

                    switch (item)
                    {
                        case '#':
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
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
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        case ')':
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                    Console.Write(item);
                }

                Console.WriteLine();
            }

            if (Enemy_Id >= 0)
            {
                Character Enemy = Bosses.BossesToBeat[Enemy_Id];
                Enemy.Draw();
            }

            Character Friend = Party.PartyMembers[Friend_Id];
            Friend.Draw();
        }

        public int Collisions(int eeveeX, int eeveeY)
        {
            switch(myMap[eeveeY, eeveeX])
            {
                case '<':
                case '>':
                    return 1;
                case '^':
                    return 2;
                case '/':
                    return 3;
                case '\\':
                    return 3;
                case '-':
                    return 3;
                case '|':
                    return 3;
                case '+':
                    return 3;
                case 'v':
                    return 4;
                case '#':
                    return 5;
            }
            return 0;
        }

        public void AddCursor(int x, int y)
        {
            _cursorY = y;
            //battle x = 55

            Console.SetCursorPosition(x, y);
            Console.Write("►");
        }

        public void MoveCursor(char input, int length)
        {
            Console.SetCursorPosition(1, _cursorY);
            Console.Write(" ");

            switch (input)
            {
                case 'z':
                    _cursorY = _cursorY == 2 ? _cursorY : _cursorY -= 1;
                    break;
                case 's':
                    _cursorY = _cursorY == length + 1 ? _cursorY : _cursorY += 1;
                    break;

            }

            Console.SetCursorPosition(1, _cursorY);
            Console.Write("►");
        }

        public void GrassBattle()
        {

        }
    }

}