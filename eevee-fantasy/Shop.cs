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
        public static List<int>? Item;
        public static Menu menu { get; private set; }
        public static bool IsOpen { get; private set; }

        public static void Init()
        {
            _cursorY = 2;
            IsOpen = false;
            Items = new List<Item> { new AtkPotion(), new Elixir(), new Revive(), new Potion(), new SuperPotion(), new HyperPotion() };
            Item = new List<int> { 0, };
        }

        public static void Open()
        {
            IsOpen = true;
            menu = new Menu();
            menu.DrawShop(Items);
            menu.AddCursor(1, 2);
        }

        public static void Close()
        {
            IsOpen = false;
        }
    }  
}

