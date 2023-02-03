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
            Bosses.Init();
            Inventory.Init();
            Shop.Init();
            eevee = Game.Init(eevee);

            Map[]? maps = new Map[9] { new MapZero(), new MapOne(), new MapTwo(), new MapThree(), new MapFour(), new MapJolteon(), new MapFive(), new MapZero2(), new MapEnd() };
            int map = Game.GameLevel;
            Map currentMap = maps[map];
            currentMap.DrawMap();
            eevee.Spawn(eevee.X != 0 ? eevee.X : currentMap.X, eevee.Y != 0 ? eevee.Y : currentMap.Y);

            Battle battle = new Battle();

            while (play != false)
            {

                ConsoleKeyInfo input = Console.ReadKey(true);
                if (!Inventory.IsOpen && !Party.IsOpen && !Shop.IsOpen && !battle.BattleState)
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
                           
                          
                            Inventory.Choice();
                            currentMap.DrawMap();
                            eevee.Spawn(eevee.X, eevee.Y);
                            break;
                        case 'p':
                           Party.Swap(Party.ChoosePokemon(), Party.ChoosePokemon());
                            currentMap.DrawMap();
                            eevee.Spawn(eevee.X, eevee.Y);
                            break;
                        case 'n':
                            Game.CreateSave(eevee);
                            new Dialogue("Game saved !");
                            currentMap.DrawMap();
                            eevee.Spawn(eevee.X, eevee.Y);
                            break;
                        case 'b':
                            Shop.Open();
                            break;
                        case 'm': //Debug only
                            new Dialogue("A tall mountain is right in front of you.");
                            currentMap.DrawMap();
                            eevee.Spawn(eevee.X, eevee.Y);
                            break;
                        case 'k': //Debug only
                            //Game.DeleteSave();
                            Game.GameOver();
                            currentMap = maps[0];
                            currentMap.DrawMap();
                            eevee.Spawn(currentMap.X, currentMap.Y);
                            break;
                    }
                }
                else if (Inventory.IsOpen && (input.KeyChar == 'z' || input.KeyChar == 's'))
                {
                    Inventory.MoveCursor(input.KeyChar);
                }
                else if (Party.IsOpen && (input.KeyChar == 'z' || input.KeyChar == 's'))
                {
                    Party.PartyMenu.MoveCursor(input.KeyChar, Party.BattlePartyMembers.Count);
                }
                else if (Shop.IsOpen && (input.KeyChar == 'z' || input.KeyChar == 's'))
                {
                    Inventory.MoveCursor(input.KeyChar);
                }
                else if (Inventory.IsOpen && (input.Key == ConsoleKey.Escape || input.KeyChar == 'i'))
                {
                    Inventory.Close();
                    currentMap.DrawMap();
                    eevee.Spawn(eevee.X, eevee.Y);
                }
                else if (Party.IsOpen && (input.Key == ConsoleKey.Escape || input.KeyChar == 'p'))
                {
                    Party.Close();
                    currentMap.DrawMap();
                    eevee.Spawn(eevee.X, eevee.Y);
                }
                else if (Shop.IsOpen && (input.Key == ConsoleKey.Escape || input.KeyChar == 'b'))
                {
                    Shop.Close();
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
                }
                else if (currentMap.Collisions(eevee.X, eevee.Y) == 5)
                {
                    Random rnd = new Random();
                    if (rnd.Next(1, 100) >= 90)
                    {
                        Character myEnemyToFight = new BasicEnemy(rnd.Next(maps[Game.GameLevel - 1].levelCap, currentMap.levelCap), rnd.Next(1, 6));
                        battle.Init(myEnemyToFight, currentMap);
                    }
                }

                else if (currentMap.Collisions(eevee.X, eevee.Y) == 6)
                {
                    Random rnd = new Random();
                    if (rnd.Next(1, 100) >= 90)
                    {
                        Character myEnemyToFight = new BasicEnemy(rnd.Next(maps[Game.GameLevel - 1].levelCap, currentMap.levelCap), 3);
                        battle.Init(myEnemyToFight, currentMap);
                    }
                }
                else if (currentMap.Collisions(eevee.X, eevee.Y) == 7)
                {
                    Random rnd = new Random();
                    if (rnd.Next(1, 100) >= 90)
                    {
                        Character myEnemyToFight = new BasicEnemy(rnd.Next(maps[Game.GameLevel - 1].levelCap, currentMap.levelCap), 4);
                        battle.Init(myEnemyToFight, currentMap);
                    }
                }
                
                if (currentMap.Friend_Id > 0)
                {
                    Character friend = Party.PartyMembers[currentMap.Friend_Id];
                    if (map != 0 && (eevee.X == friend.X && eevee.Y == friend.Y))
                    {
                        new Dialogue(friend.Name + " has joined your team !");
                        currentMap.DrawMap();
                        eevee.Spawn(eevee.X, eevee.Y);
                        Party.Recruit(currentMap.Friend_Id);
                    }
                }

                if (currentMap.Enemy_Id >= 0)
                {
                    BossEnemy enemy = Bosses.BossesToBeat[currentMap.Enemy_Id];
                    if (eevee.X == enemy.X && eevee.Y == enemy.Y)
                    {
                        enemy.giveBestAttribute();
                        battle.Init(enemy, currentMap);
                        enemy.Beaten = true;
                    }

                }

            }
        }
    }
}


