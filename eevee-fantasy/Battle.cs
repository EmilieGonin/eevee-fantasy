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

        public void Init(enemy)
        {
            BattleState = true;
            _choiceDone = false;
            _choiceIndex = 0;
/           if (enemy is BossEnemy )
            {

            }
            //Drawing Battle Background
            BattleMap = new BattleMap();
            BattleMap.DrawMap();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(35, 1);
            Console.Write("Battle !");

            //Creating Enemy
            Enemy = new BasicEnemy(25);
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
            if (BattleState == true )
            {
                //Console.WriteLine("je calcule wsh");
                MyTurn();
                if (Enemy.Alive == false)
                {
                    
                    BattleState = false;
                    Character.WinXp((int)(Enemy.lvl * Enemy.XpGain) / 7);
                    // vous avez gagné tant d'xp
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
                Console.WriteLine(Character.Name + "  Turn");
                switch (Choice(2))
                {
                    case 0:
                        if (Character?.Speed < Enemy?.Speed)
                        {
                            Skill skillUsed = Character.Skills[Choice(Character.Skills.Count() - 1)];
                            EnnemysTurn();
                            if(Character.Alive == true)
                            {
                                Attack(Character, Enemy, skillUsed);
                            }
                           

                        }
                        else if (Character?.Speed > Enemy?.Speed)
                        {
                            Skill skillUsed = Character.Skills[Choice(Character.Skills.Count() - 1)];
                            Attack(Character, Enemy, Character.Skills[Choice(Character.Skills.Count() - 1)]);
                            EnnemysTurn();

                        }
                       
                        break;
                    case 1:
                        Inventory.Open();
                        Console.WriteLine("j'ouvre mon inventaire");

                        EnnemysTurn();
                        break;
                    case 2:

                        Console.WriteLine("Choose pokemon to swap");
                        Character pokemon = ChoosePokemon();

                        Party.Swap(Character, pokemon);
                        Character = pokemon;
                        EnnemysTurn();

                        break;
                }
            }
            else
            {
                bool partyAvailable = false;
                for (int i = 0; i < Party.BattlePartyMembers.Count(); i++)
                {
                    if (Party.BattlePartyMembers[i].Alive == true)
                    {
                        partyAvailable = true;
                        break;
                    }
                }
                if (partyAvailable)
                {
                    Character pokemon2 = ChoosePokemon();
                    Party.Swap(Character, pokemon2) ;
                    Character = pokemon2;

                }
                else
                {
                    Console.WriteLine("Game Over");
                    BattleState = false;
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

            int myChoice = 0;
            do
            {
                
                myChoice = Choice(Party.BattlePartyMembers.Count() - 1);
                ;
            } while (Party.BattlePartyMembers[myChoice].Alive == false);

            Console.WriteLine(Party.BattlePartyMembers[myChoice].Name);
            return Party.BattlePartyMembers[myChoice];
        }

        private void Attack(Character attacker, Character target, Skill skillUsed)
        {

            skillUsed.Use(attacker, target);


        }

        private int Choice(int choiceLimit)
        {
            ConsoleKeyInfo input = Console.ReadKey(true);
            int Index = 0;
            _choiceDone = false;
            do
            {

                if (Console.ReadKey().Key == ConsoleKey.UpArrow && Index < choiceLimit)
                {

                    Index += 1;
                    Console.WriteLine(Index);
                }
                else if (Console.ReadKey().Key == ConsoleKey.DownArrow && Index > 0)//var to check skill unlocked
                {

                    Index -= 1;
                    Console.WriteLine(Index);
                }
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    _choiceDone = true;
                }
            } while (_choiceDone == false);

            return Index;
        }
    }
}
