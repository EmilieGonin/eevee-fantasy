using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{
    public class Battle
    {
        private Map _currentMap;
        private Character? Character;
        private Character? Enemy;
        private BattleMap? BattleMap;
        private int _choiceIndex;
        private bool _choiceDone;
        public bool BattleState { get; set; }

        public Battle()
        {
            BattleState = false;
        }

        public void Init(Character enemy, Map map)
        {

             foreach (var member in Party.BattlePartyMembers!)
            {
                if (Party.PartyMembers[member].Alive == true)
                {
                    Character = Party.PartyMembers[member];
                    break;
                }
            }
            BattleState = true;
            _choiceDone = false;
            _choiceIndex = 0;
            _currentMap = map;

            //Drawing Battle Background

            DrawMyBackground(enemy);
            Play();
        }
        public void DrawMyBackground(Character enemy)
        {
            BattleMap = new BattleMap();
            BattleMap.DrawMap();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(35, 1);
            Console.Write("Battle !");

            //Creating Enemy
            Enemy = enemy;
            DrawEnemy();

            //Console.WriteLine(Enemy.Speed);

            DrawCharacter();

            //Create Menu
            DrawMenu();

            BattleMap.AddCursor(55, 15);

            //Add default text
            Write("Choose an action.");
        }
        private void DrawCharacter()
        {
           

            AttributeColor(Character.Attribute.Id);
            Console.SetCursorPosition(3, 7);
            Console.Write(Character.BattleHp + "/" + Character.TotalHp + " -- " + Character.Name + " lvl " + Character.lvl);
            Console.SetCursorPosition(10, 9);
            Console.Write("E");
        }

        private void DrawEnemy()
        {
            AttributeColor(Enemy.Attribute.Id);
            Console.SetCursorPosition(50, 3);
            Console.Write(Enemy.BattleHp + "/" + Enemy.TotalHp + " -- Enemy lvl " + Enemy.lvl);
            Console.SetCursorPosition(60, 5);
            Console.Write("@");
        }

        private void DrawMenu()
        {
            ResetChoices();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(58, 15);
            Console.Write("Attack");
            Console.SetCursorPosition(58, 16);
            Console.Write("Select Item");
            Console.SetCursorPosition(58, 17);
            Console.Write("Change Pokemon");
        }

        private void DrawSkillsMenu()
        {
            ResetChoices();
            Write("Choose a move.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(58, 15);

            for (int i = 0; i < Character.Skills.Count; i++)
            {
                Console.SetCursorPosition(58, 15 + i);
                Console.Write(Character.Skills[i].Name);
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

        public void Play()
        {
            BattleMap.ResetCursor(55, 15);
            DrawMyBackground(Enemy);
            //Console.WriteLine("start battle");
            if (BattleState == true )
            {
                //Console.WriteLine("je calcule wsh");
                MyTurn();
                if (Enemy.Alive == false)
                {
                    
                    BattleState = false;
                    int xp = (Enemy.lvl * Enemy.XpGain) / 7;
                    int money = (Enemy.lvl * 2) + 20;
                    Inventory.PokeDollars += money;
                    
                    Character.WinXp(xp);
                    new Dialogue("You gain " + xp + "exp and " + money +" pokedollars");
                    _currentMap.DrawMap();
                    
                }
                else
                {
                    Play();
                }
            }
        }

        private void MyTurn()
        {
          
            if (Character.Alive == true)
            {
                //Console.WriteLine(Character.Name + "  Turn");
                switch (Choice(2))
                {
                    case 0: //Attack
                        DrawSkillsMenu();

                        if (Character?.Speed < Enemy?.Speed)
                        {
                            Skill skillUsed = Character.Skills[Choice(Character.Skills.Count() - 1)];
                            EnnemysTurn();
                            if(Character.Alive == true)
                            {
                                new Dialogue(Character.Name + " use " + skillUsed.Name);
                                Attack(Character, Enemy, skillUsed);
                            }
                        }
                        else if (Character?.Speed >= Enemy?.Speed)
                        {
                            Skill skillUsed = Character.Skills[Choice(Character.Skills.Count() - 1)];
                            new Dialogue(Character.Name + " use " + skillUsed.Name);
                            Attack(Character, Enemy, skillUsed);
                            EnnemysTurn();
                            
                        }
                        DrawMenu();
                        break;
                    case 1: //Inventory
                        Inventory.Open();

                        if (Inventory.Choice() == false)
                        {
                            DrawMyBackground(Enemy);
                            DrawMenu();
                            break;
                        }
                        else
                        {
                            DrawMyBackground(Enemy);
                            DrawMenu();
                            EnnemysTurn();
                        }
                        break;
                    case 2: //Choose Pokemon
                        if (Party.BattlePartyMembers.Count < 2 && isPartyAvailable())
                        {
                            new Dialogue("You have no Pokemon available to swap.");
                            Choice(2);
                        }
                        else
                        {
                            
                            Character pokemon = Party.ChoosePokemon();
                            if (Party.Swap(Character, pokemon))
                            {
                                Character = pokemon; 
                                DrawMyBackground(Enemy);
                                DrawMenu();
                                EnnemysTurn();
                                DrawMyBackground(Enemy);
                            }
                            else
                            {
                                Console.WriteLine("hihi");
                                break;
                            }
                           
                           
                        }
                        break;
                }
            }
            else
            {
                if (isPartyAvailable())
                {
                    Character pokemon2 = Party.ChoosePokemon();
                    Party.Swap(Character, pokemon2) ;
                    Character = pokemon2;
                    
                }
                else
                {
                    BattleState = false;
                    new Dialogue("Game Over.");
                    _currentMap = new MapZero();
                    _currentMap.DrawMap();
                }
            }
            //attack function
        }
        private bool isPartyAvailable()
        {
            for (int i = 0; i < Party.BattlePartyMembers.Count(); i++)
            {
                if (Party.PartyMembers[Party.BattlePartyMembers[i]].Alive == true)
                {
                    return true;
                }
            }

            return false;
        }
        private void EnnemysTurn()
        {
            if (Enemy.Alive == true)
            {
                //Console.WriteLine("ennemy turn");
                Random rnd = new Random();
                if (Enemy!.Attribute!.isEffective(Character!.Attribute!))
                {
                    int indexChoice = rnd.Next(1, Enemy.Skills.Count());
                    //Console.WriteLine("It's gonna be super effective : skill n° " + indexChoice + " used ");
                    Attack(Enemy, Character, Enemy.Skills[indexChoice]);
                    new Dialogue("The ennemy use " + Enemy.Skills[indexChoice].Name + ". It's super effective !");
                }
                else if (Enemy!.Attribute!.isWeak(Character!.Attribute!))
                {
                    //Console.WriteLine("It's gonna be weak so tackle");
                    Attack(Enemy, Character, Enemy.Skills[0]);
                    new Dialogue("The ennemy use Tackle.");
                }
                else
                {
                    int indexChoice = rnd.Next(0, Enemy.Skills.Count());
                    //Console.WriteLine("It's gonna be neutral  : skill n° " + indexChoice + " used ");
                    Attack(Enemy, Character, Enemy.Skills[indexChoice]);
                    new Dialogue("The ennemy use " + Enemy.Skills[indexChoice].Name + ".");
                }
            }

        }



        private void Attack(Character attacker, Character target, Skill skillUsed)
        {
            skillUsed.Use(attacker, target);
        }

        private int Choice(int choiceLimit)
        {
            int Index = 0;
            _choiceDone = false;
            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.UpArrow || input.Key == ConsoleKey.DownArrow || input.KeyChar == 'z' || input.KeyChar == 's')
                {

                    if ((input.Key == ConsoleKey.UpArrow || input.KeyChar == 'z') && Index > 0)
                    {
                        Index -= 1;
                        BattleMap.MoveCursor(input.KeyChar, choiceLimit + 1) ;
                    }
                    else if ((input.Key == ConsoleKey.DownArrow || input.KeyChar == 's') && Index < choiceLimit)//var to check skill unlocked
                    {
                        Index += 1;
                        BattleMap.MoveCursor(input.KeyChar, choiceLimit + 1);
                    }
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    Reset();
                    _choiceDone = true;
                }
            } while (_choiceDone == false);

            return Index;
        }

        private void Write(string text)
        {
            Console.SetCursorPosition(2, 15);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
        }

        private void Reset()
        {
            Console.SetCursorPosition(2, 15);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("                                                ");
            Write("Choose an action.");
        }

        private void ResetChoices()
        {
            Console.SetCursorPosition(55, 15);
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(55, 15 + i);
                Console.Write("                   ");
            }
        }
    }
}
