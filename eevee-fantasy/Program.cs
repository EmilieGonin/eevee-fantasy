using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eevee_fantasy;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{
    public class Program
    {
        public static void Main()
        {
            Console.SetWindowSize(75, 25);
            Console.CursorVisible = false;
            bool play = true;

            Eevee eevee = new Eevee();
            Party.Fill(eevee);

            Game.Init(eevee);
            Inventory.Init();

            Map[]? maps = new Map[4] { new MapZero(), new MapOne(), new MapTwo(), new MapThree() };
            int map = Game.GameLevel;
            Map currentMap = maps[map];
            currentMap.DrawMap();
            eevee.Spawn(currentMap.X, currentMap.Y);

            Battle battle = new Battle();

            while (play != false)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (!Inventory.IsOpen && !battle.BattleState)
                {
                    if (input.KeyChar == 'z' && (currentMap.Collisions(eevee.X, eevee.Y - 1) != true))
                    {
                        currentMap.DrawMap();
                        eevee.Move(input.KeyChar);
                    }
                    else if (input.KeyChar == 's' && (currentMap.Collisions(eevee.X, eevee.Y + 1) != true))
                    {
                        currentMap.DrawMap();
                        eevee.Move(input.KeyChar);
                    }
                    else if (input.KeyChar == 'q' && (currentMap.Collisions(eevee.X - 1, eevee.Y) != true))
                    {
                        currentMap.DrawMap();
                        eevee.Move(input.KeyChar);
                    }
                    else if (input.KeyChar == 'd' && (currentMap.Collisions(eevee.X + 1, eevee.Y) != true))
                    {
                        currentMap.DrawMap();
                        eevee.Move(input.KeyChar);
                    }
                    else if (input.KeyChar == 'i')
                    {
                        Inventory.Open();
                    }
                    else if (input.KeyChar == 'p')
                    {
                        //Open Pokemon
                    }
                    else if (input.Key == ConsoleKey.Tab)
                    {
                        Game.CreateSave(eevee);
                    }
                    else if (input.KeyChar == 'b')
                    {
                        battle.Init();
                    }
                }
                else if (Inventory.IsOpen && (input.KeyChar == 'z' || input.KeyChar == 's'))
                {
                    Inventory.MoveCursor(input.KeyChar);
                }
                else if (Inventory.IsOpen && (input.Key == ConsoleKey.Escape || input.KeyChar == 'i'))
                {
                    Inventory.Close();
                    currentMap.DrawMap();
                    eevee.Spawn(eevee.X, eevee.Y);
                }
                //if (currentMap.Tp(eevee.X, eevee.Y))
                //{
                //    currentMap = maps[Game.GameLevel];
                //    currentMap.DrawMap();
                //    eevee.Spawn(currentMap.X, currentMap.Y);
                //}
                if (currentMap.Tp(eevee.X, eevee.Y) == 1)
                {
                    map += 1;
                    currentMap = maps[map];
                    currentMap.DrawMap();
                    eevee.Spawn(currentMap.X, currentMap.Y);
                }
                else if (currentMap.Tp(eevee.X, eevee.Y) == 2)
                {
                    map -= 1;
                    currentMap = maps[map];
                    currentMap.DrawMap();
                    eevee.Spawn(currentMap.X_Pre, currentMap.Y_Pre);
                }
            }
        }
    }
}