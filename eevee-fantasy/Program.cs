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
            Party.Recruit(1);


            BossEnemy bossenemies = new BossEnemy();
            Bosses.Dead(bossenemies);
            Game.Init(eevee);
            Inventory.Init();

            Map[]? maps = new Map[7] { new MapZero(), new MapOne(), new MapTwo(), new MapThree(), new MapFour(), new MapJolteon(), new MapFive() };
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
                if (currentMap.Collisions(eevee.X, eevee.Y) == 1)
                {
                    map += 1;
                    Game.GameLevel = map;
                    currentMap = maps[map];
                    currentMap.DrawMap();
                    eevee.Spawn(currentMap.X, currentMap.Y);
                    //Console.WriteLine(map);
                    //Console.WriteLine(Game.GameLevel);
                }
                else if (currentMap.Collisions(eevee.X, eevee.Y) == 4)
                {
                    switch (Game.GameLevel)
                    {
                        case 4:
                            map += 2;
                            break;
                        default:
                            map += 1;
                            break;
                    }
                    Game.GameLevel = map;
                    currentMap = maps[map];
                    currentMap.DrawMap();
                    eevee.Spawn(currentMap.X, currentMap.Y);
                }
                else if (currentMap.Collisions(eevee.X, eevee.Y) == 2)
                {
                    switch (Game.GameLevel)
                    {
                        case 6:
                            map -= 2;
                            break;
                        default:
                            map -= 1;
                            break;
                    }
                    if (Game.GameLevel == 5)
                    {
                        currentMap = maps[map];
                        currentMap.DrawMap();
                        eevee.Spawn(currentMap.X_PreJolt, currentMap.Y_PreJolt);
                    }
                    else
                    {
                        currentMap = maps[map];
                        currentMap.DrawMap();
                        eevee.Spawn(currentMap.X_Pre, currentMap.Y_Pre);
                    }
                    Game.GameLevel = map;
                    //Console.WriteLine(Game.GameLevel);
                }

                Character friend = Party.PartyMembers[currentMap.Friend_Id];
                if (eevee.X == friend.X && eevee.Y == friend.Y)
                {
                    //Console.WriteLine("test");
                    Party.Recruit(currentMap.Friend_Id);

                }

                Character enemy = Bosses.BossesToBeat[currentMap.Enemy_Id];
                if (eevee.X == enemy.X && eevee.Y == enemy.Y)
                {
                    //battle.Init();
                    enemy.Beaten = true;
                }

            }
        }
    }
}


