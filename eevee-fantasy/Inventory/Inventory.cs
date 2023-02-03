using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
	public static class Inventory
	{
        public static int _cursorY { get; private set; }
        public static int PokeDollars { get; private set; }
        public static Item[]? Items { get; set; }
        public static bool IsOpen { get; private set; }

        public static void Init()
        {
            _cursorY = 2;
            IsOpen = false;
            PokeDollars = 1000;
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

