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
            menu.DrawShop(Items);
            menu.AddCursor(1, 2);
        }

        public static void Close()
        {
            IsOpen = false;
        }
    }

       
    
}

