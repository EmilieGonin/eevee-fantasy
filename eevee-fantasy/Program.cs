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
            //Console.SetWindowSize(75, 25);
            Console.CursorVisible = false;
            bool play = true;

            Eevee eevee = new Eevee();
            Party.Fill(eevee);

            Game.Init(eevee);
            Inventory.Init();

            Map[]? maps = new Map[6] { new MapZero(), new MapOne(), new MapTwo(), new MapThree(), new MapFour(), new MapFive() }; //new MapJolteon()
            int map = Game.GameLevel;
            Map currentMap = maps[map];
            currentMap.DrawMap();
            eevee.Spawn(eevee.X != 0 ? eevee.X : currentMap.X, eevee.Y != 0 ? eevee.Y : currentMap.Y);

            Battle battle = new Battle();

            while (play != false)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (!Inventory.IsOpen && !battle.BattleState)
                {
                    switch (input.KeyChar)
                    {
                        case 'z':
                            if (currentMap.Collisions(eevee.X, eevee.Y - 1) != 3)
                            {
                                currentMap.DrawMap();
                                eevee.Move(input.KeyChar);
                            }
                            break;
                        case 'q':
                            if (currentMap.Collisions(eevee.X - 1, eevee.Y) != 3)
                            {
                                currentMap.DrawMap();
                                eevee.Move(input.KeyChar);
                            }
                            break;
                        case 's':
                            if (currentMap.Collisions(eevee.X, eevee.Y + 1) != 3)
                            {
                                currentMap.DrawMap();
                                eevee.Move(input.KeyChar);
                            }
                            break;
                        case 'd':
                            if (currentMap.Collisions(eevee.X + 1, eevee.Y) != 3)
                            {
                                currentMap.DrawMap();
                                eevee.Move(input.KeyChar);
                            }
                            break;
                        case 'i':
                            Inventory.Open();
                            break;
                        case 'p':
                            //Open Pokemon
                            break;
                        case 'n':
                            Game.CreateSave(eevee);
                            new Dialogue("Game saved !");
                            currentMap.DrawMap();
                            eevee.Spawn(eevee.X, eevee.Y);
                            break;
                        case 'b': //Debug only
                            battle.Init();
                            break;
                        case 'm': //Debug only
                            new Dialogue("A tall mountain is right in front of you.");
                            currentMap.DrawMap();
                            eevee.Spawn(eevee.X, eevee.Y);
                            break;
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
                if (currentMap.Collisions(eevee.X, eevee.Y) == 1)
                {
                    map += 1;
                    currentMap = maps[map];
                    currentMap.DrawMap();
                    eevee.Spawn(currentMap.X, currentMap.Y);
                }
                else if (currentMap.Collisions(eevee.X, eevee.Y) == 2)
                {
                    map -= 1;
                    currentMap = maps[map];
                    currentMap.DrawMap();
                    eevee.Spawn(currentMap.X_Pre, currentMap.Y_Pre);
                }

                Character friend = Party.PartyMembers[currentMap.Friend_Id];
                if (eevee.X == friend.X && eevee.Y == friend.Y)
                {
                    //Console.WriteLine("test");
                    friend.Recruited = true;
                }
            }
            
        }


        Battle battle = new Battle();
    }
}
