using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
	public static class Inventory
	{
        private static int _cursorY;
        public static int PokeDollars { get; private set; }
        public static Item[]? Items { get; set; }
        public static bool IsOpen { get; private set; }

        public static void Init()
        {
            _cursorY = 2;
            IsOpen = false;
            Items = new Item[6] { new AtkPotion(), new Elixir(), new Revive(), new Potion(), new SuperPotion(), new HyperPotion() };
        }

        public static void Open()
        {
            IsOpen = true;
            Menu menu = new Menu();
            menu.DrawList(Items);
            menu.AddCursor(1, 2);
        }

        public static void Close()
        {
            _cursorY= 2;
            IsOpen = false;
        }

        public static void MoveCursor(char input)
        {
            
            Console.SetCursorPosition(1, _cursorY);
            Console.Write(" ");
            switch (input)
            {
                case 'z':
                    _cursorY = _cursorY == 2 ? _cursorY : _cursorY -= 1;
                    break;
                case 's':
                    _cursorY = _cursorY == Items.Length + 1 ? _cursorY : _cursorY += 1;
                    break;

            }

            Console.SetCursorPosition(1, _cursorY);
            Console.Write("►");
        }
        /*public static Item chooseItem()
        {
          
            //BattleMap.AddCursor(1, 2);
         
            int myChoice = 0;
            Choice();
          
        }
*/
        public static void Choice()
        {
            Open();
            Console.SetCursorPosition(1, 2);
            int Index = 0;
            bool _choiceDone = false;
            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.UpArrow || input.Key == ConsoleKey.DownArrow || input.KeyChar == 'z' || input.KeyChar == 's')
                {

                    if ((input.Key == ConsoleKey.UpArrow || input.KeyChar == 'z') && Index > 0)
                    {
                        Index -= 1;
                        MoveCursor(input.KeyChar);
                    }
                    else if ((input.Key == ConsoleKey.DownArrow || input.KeyChar == 's') && Index < Items.Length)//var to check skill unlocked
                    {
                        Index += 1;
                        MoveCursor(input.KeyChar);
                    }
                }
                else if (input.Key == ConsoleKey.Escape)
                {
                    Close();
                    break;
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    Close();
                    _choiceDone = true;
                    Items[Index].Use(Party.ChoosePokemon());
                }
            } while (_choiceDone == false || Items[Index].Number == 0);
        }
        public static void Buy(int id)
        {
            if (PokeDollars > Items[id].Price)
            {
                Items[id].Number++;
                PokeDollars -= Items[id].Price;
            }
        }
    }
}

