using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class Menu : Map
    {
        public Menu()
        {
            MapLink = "Inventory.txt";
            CreateMap();
            DrawMap();
        }

        public override void DrawMap()
        {
            Console.Clear();
            base.DrawMap();
        }

        public void DrawList(Item[] list)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(30, 1);
            Console.Write("Inventory");
            Console.SetCursorPosition(50, 2);
            Console.Write("PokeDollars = " + Inventory.PokeDollars + "$");

            for (int i = 0; i < list!.Length; i++)
            {
                Console.SetCursorPosition(1, i + 2);
                Console.Write("  " + list[i].Name + " x" + list[i].Number);
            }
        }

        public void DrawShop(List<Item> list)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(30, 1);
            Console.Write("Item Shop");
            Console.SetCursorPosition(50, 2);
            Console.Write("PokeDollars = " + Inventory.PokeDollars + "$");

            for (int i = 0; i < list!.Count; i++)
            {
                Console.SetCursorPosition(1, i + 2);
                Console.Write("  " + list[i].Name + " = " + list[i].Price + " $ ");
            }
        }

        public void DrawList(List<Character> list)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(30, 1);
            Console.Write("Pokemons");

            for (int i = 0; i < list!.Count; i++)
            {
                if (list[i].Recruited)
                {
                    AttributeColor(list[i].Attribute.Id);
                    Console.SetCursorPosition(1, i + 2);
                    Console.Write("  " + list[i].Name + " lvl " + list[i].lvl + " -- "
                        + "HP=" + list[i].BattleHp + "/" + list[i].TotalHp + " ATK=" + list[i].TotalAtk + " DEF=" + list[i].TotalDef + " SPD=" + list[i].Speed);
                }
            }
        }

        public void AttributeColor(int id)
        {
            switch (id)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
            }
        }
    }
}
