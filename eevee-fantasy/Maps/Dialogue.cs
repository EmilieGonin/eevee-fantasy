using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Dialogue : Map
    {
        public Dialogue(string text)
        {
            DrawY = 16;
            MapLink = "Dialogue.txt";
            CreateMap();
            DrawMap();
            Write(text);
        }

        private void Write(string text)
        {
            Console.SetCursorPosition(2, 18);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);

            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}
