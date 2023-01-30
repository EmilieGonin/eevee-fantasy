using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Battle
    {
        

        private Character? Character;
        private Character? Enemy;
        private int _choiceIndex;
        private bool _choiceDone, _battleState;
        


        public Battle(Party myParty)
        {
            foreach(var member in myParty.PartyMembers)
            {
                if (member.Alive == true)
                {
                    
                    Character = member;
                    Console.WriteLine(Character.Speed);
                    break;
                }
            }

            _battleState = true;
            _choiceDone= false;
           
            Enemy = new BasicEnemy();

            Console.WriteLine(Enemy.Speed);
            _choiceIndex = 0;

            Play();
        }
        public void Play()
        {

            Console.WriteLine("start battle");
            if (_battleState == true)
            {
                Console.WriteLine("je calcule wsh");
                if (Character?.Speed < Enemy?.Speed)
                {

                    EnnemysTurn();
                }
                else if (Character?.Speed > Enemy?.Speed)
                {
                    MyTurn();
                  

                }
                Play();
            }
        }

        private void MyTurn()
        {
            // choice between inventory, attack or party change

                //choose skill
                do
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.UpArrow && _choiceIndex < 3)
                    {
                        _choiceIndex += 1;
                        Console.WriteLine(_choiceIndex);

                    }
                    else if (Console.ReadKey(true).Key == ConsoleKey.DownArrow && _choiceIndex > 0 ) //var to check skill unlocked
                    {
                        _choiceIndex -= 1;
                        Console.WriteLine(_choiceIndex);
                    }
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                       _choiceDone  = true;
                        Console.WriteLine("Je selectionne");

                    }
                } while (!_choiceDone);

                switch (_choiceIndex)
                {
                    case 0:
                        Console.WriteLine("j'attaque");
                        _choiceDone= false;
                        do
                        {
                            if (Console.ReadKey().Key == ConsoleKey.UpArrow && _choiceIndex < 0)
                            {
                                _choiceIndex += 1;

                            }
                            else if (Console.ReadKey().Key == ConsoleKey.DownArrow && _choiceIndex > 4) //var to check skill unlocked
                            {
                                _choiceIndex -= 1;

                            }
                            if (Console.ReadKey().Key == ConsoleKey.Enter)
                            {
                                _choiceDone = true;

                            }
                        } while (!_choiceDone);
                        Console.WriteLine("skill" + _choiceIndex + "used");
                        //Attack(Character, Enemy, Character.Skills[_choiceIndex]);
                        break;
                    case 1:
                        Console.WriteLine("j'ouvre mon inventaire");
                        break;
                    case 2:
                        Console.WriteLine("je change de pokemon");
                        break;
                }
                //attack function
            
        }
        private void EnnemysTurn()
        {
            // AI to determine who's enemy the best to attack 
        }

        private void Attack(Character attacker, Character target, Skill skillUsed)
        {
            
            skillUsed.Use(attacker.Attribute, target);

        }



    }
}
