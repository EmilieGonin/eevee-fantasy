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
            Console.Write("Items Inventory");

            for (int i = 0; i < list!.Length; i++)
            {
                Console.SetCursorPosition(1, i + 2);
                Console.Write("  " + list[i].Name + " x" + list[i].Number);
            }
        }

        public void DrawList(List<Character> list)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(30, 1);
            Console.Write("Pokemons");

            for (int i = 0; i < list!.Count; i++)
            {
                Console.SetCursorPosition(1, i + 2);
                Console.Write("  " + list[i].Name + " lvl " + list[i].lvl + " -- "
                    + "HP=" + list[i].BattleHp + "/" + list[i].TotalHp + " ATK=" + list[i].TotalAtk + " DEF=" + list[i].TotalDef + " SPD=" + list[i].Speed);
            }
        }
    }
}
