using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
	public class Shop
	{
        private static int _cursorY;
        public static List<Item>? Items;
        public static Menu menu { get; private set; }
        public static bool IsOpen { get; private set; }

        public static void Init()
        {
            _cursorY = 2;
            IsOpen = false;
            Items = new List<Item> { new AtkPotion(), new Elixir(), new Revive(), new Potion(), new SuperPotion(), new HyperPotion() };
        }

        public static void Open()
        {
            IsOpen = true;
            menu = new Menu();
            menu.DrawShop(Items);
            menu.AddCursor(1, 2);
        }

        public static bool Choice()
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
                        menu.MoveCursor(input.KeyChar, Inventory.Items.Length);
                    }
                    else if ((input.Key == ConsoleKey.DownArrow || input.KeyChar == 's') && Index < Inventory.Items.Length)//var to check skill unlocked
                    {
                        Index += 1;
                        menu.MoveCursor(input.KeyChar, Inventory.Items.Length);
                    }
                }
                else if (input.Key == ConsoleKey.Escape)
                {
                    Close();
                    return false;
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    Inventory.Buy(Index);
                    return true;
                }
            } while (_choiceDone == false || Items[Index].Number == 0);
            return false;
        }

        public static void Close()
        {
            IsOpen = false;
        }
    }  
}

