using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
	public static class Inventory
	{
        public static int PokeDollars { get; private set; }
        public static Item[]? Items { get; private set; }

        public static void Init()
        {
            Items = new Item[6] { new AtkPotion(), new Elixir(), new Revive(), new Potion(), new SuperPotion(), new HyperPotion() };
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

