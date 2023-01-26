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
        private bool _choiceDone;
        


        public Battle(Party myParty, Character enemy)
        {
            foreach(var member in myParty.PartyMembers)
            {
                if (member.Alive == true)
                {
                    Character = member;
                    break;
                }
            }
           
            Enemy = enemy;
            _choiceIndex = 0;

        }


        private void MyTurn()
        {
            // choice between inventory, attack or party change

            if (_choiceIndex == 0)
            {
                //choose skill
                do
                {
                    if (Console.ReadKey().Key == ConsoleKey.UpArrow && _choiceIndex < 0)
                    {
                        _choiceIndex += 1;

                    }
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                       _choiceDone  = true;

                    }
                } while (!_choiceDone);

                switch (_choiceIndex) { }
                //attack function
            }
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
