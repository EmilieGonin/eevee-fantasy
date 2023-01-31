using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class Battle
    {
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

        public void Init()
        {
            BattleState = true;
            _choiceDone = false;
            _choiceIndex = 0;

            //Drawing Battle Background
            BattleMap = new BattleMap();
            BattleMap.DrawMap();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(35, 1);
            Console.Write("Battle !");

            //Creating Enemy
            Enemy = new BasicEnemy();
            AttributeColor(Enemy.Attribute.Id);
            Console.SetCursorPosition(50, 3);
            Console.Write(Enemy.BattleHp + "/" + Enemy.TotalHp + " -- Enemy lvl " + Enemy.lvl);
            Console.SetCursorPosition(60, 5);
            Console.Write("@");

            //Console.WriteLine(Enemy.Speed);

            //Creating Character
            foreach (var member in Party.BattlePartyMembers!)
            {
                if (member.Alive == true)
                {
                    Character = member;
                    break;
                }
            }

            AttributeColor(Character.Attribute.Id);
            Console.SetCursorPosition(3, 7);
            Console.Write(Character.BattleHp + "/" + Character.TotalHp + " -- " + Character.Name + " lvl " + Character.lvl);
            Console.SetCursorPosition(10, 9);
            Console.Write("E");

            //Create Menu
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(58, 15);
            Console.Write("Attack");
            Console.SetCursorPosition(58, 16);
            Console.Write("Select Item");
            Console.SetCursorPosition(58, 17);
            Console.Write("Change Pokemon");

            BattleMap.AddCursor(15);

            Play();
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
            //Console.WriteLine("start battle");
            if (BattleState == true)
            {
                //Console.WriteLine("je calcule wsh");
                if (Character?.Speed < Enemy?.Speed)
                {
                    EnnemysTurn();
                    MyTurn();
                }
                else if (Character?.Speed > Enemy?.Speed)
                {
                    MyTurn();
                    EnnemysTurn();

                }
                Play();
            }
            if (Enemy.Alive == false)
            {
                // win battle;
            }

        }

        private void MyTurn()
        {
            if (Character.Alive == true)
            {
                // choice between inventory, attack or party change
                //choose skill
                _choiceDone = false;
                _choiceIndex = 0;
                Console.WriteLine("My turn");
                do
                {
                    if (Console.ReadKey().Key == ConsoleKey.UpArrow && _choiceIndex < 2)
                    {
                        _choiceIndex += 1;
                        Console.WriteLine(_choiceIndex);
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.DownArrow && _choiceIndex >= 0) //var to check skill unlocked
                    {
                        _choiceIndex -= 1;
                        Console.WriteLine(_choiceIndex);
                    }
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        _choiceDone = true;
                        Console.WriteLine("Je selectionne");
                    }
                } while (!_choiceDone);

                switch (_choiceIndex)
                {
                    case 0:
                        Console.WriteLine(_choiceIndex);
                        _choiceDone = false;
                        _choiceIndex= 0;
                        do
                        {
                            if (Console.ReadKey().Key == ConsoleKey.UpArrow && _choiceIndex < Character.Skills.Count() - 1)
                            {
                               
                                _choiceIndex += 1;
                                Console.WriteLine(_choiceIndex);
                            }
                            else if (Console.ReadKey().Key == ConsoleKey.DownArrow && _choiceIndex >= 0)//var to check skill unlocked
                            {
                               
                                _choiceIndex -= 1;
                                Console.WriteLine(_choiceIndex);
                            }
                            if (Console.ReadKey().Key == ConsoleKey.Enter)
                            {
                                _choiceDone = true;
                            }
                        } while (!_choiceDone);
                        Console.WriteLine(Character.Skills.Count());
                        Console.WriteLine("skill" + _choiceIndex + "used");
                        Attack(Character, Enemy, Character.Skills[_choiceIndex]);
                        break;
                    case 1:
                        Console.WriteLine("j'ouvre mon inventaire");
                        break;
                    case 2:
                        Console.WriteLine("je change de pokemon");
                        break;
                }
            }
            else
            {
                bool partyAvailable = true;
                for (int i = 0; i < Party.BattlePartyMembers.Count(); i++)
                {
                    if (Party.BattlePartyMembers[i].Alive == false)
                    {
                        partyAvailable = false;
                        break;
                    }
                }
                if (partyAvailable)
                {
                    Party.ReplaceDeadPokemon(ChoosePokemon());
                }
                else
                {
                    Console.WriteLine("Game Over");
                }
            }
            //attack function
        }
        private void EnnemysTurn()
        {
            if (Enemy.Alive == true)
            {
                Console.WriteLine("ennemy turn");
                Random rnd = new Random();

                if (Enemy!.Attribute!.isEffective(Character!.Attribute!))
                {
                    int indexChoice = rnd.Next(1, Enemy.Skills.Count());
                    Console.WriteLine("It's gonna be super effective : skill n° " + indexChoice + " used ");
                    Attack(Enemy, Character, Enemy.Skills[indexChoice]);
                }
                else if (Enemy!.Attribute!.isWeak(Character!.Attribute!))
                {
                    Console.WriteLine("It's gonna be weak so tackle");
                    Attack(Enemy, Character, Enemy.Skills[0]);
                }
                else
                {
                    int indexChoice = rnd.Next(0, Enemy.Skills.Count());
                    Console.WriteLine("It's gonna be neutral  : skill n° " + indexChoice + " used ");
                    Attack(Enemy, Character, Enemy.Skills[indexChoice]);
                }
            }

        }
        private Character ChoosePokemon()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);
            _choiceIndex = 0;
            _choiceDone = false;

            do
            {
                if (Console.ReadKey().Key == ConsoleKey.UpArrow && _choiceIndex < 0)
                {
                    Console.WriteLine(_choiceIndex);
                    _choiceIndex += 1;
                }
                else if (Console.ReadKey().Key == ConsoleKey.DownArrow && _choiceIndex > Character.Skills.Count())//var to check skill unlocked
                {
                    _choiceIndex -= 1;
                }
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    _choiceDone = true;
                }
            } while (_choiceDone == false);

            return Party.BattlePartyMembers[_choiceIndex];
        }
        
        private void Attack(Character attacker, Character target, Skill skillUsed)
        {

            skillUsed.Use(attacker, target);


        }
    }
}
