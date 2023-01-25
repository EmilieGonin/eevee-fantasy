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
        


        public Battle(Character character, Character enemy)
        {
            Character = character;
            Enemy = enemy;
            _choiceIndex = 0;

        }


        private void MyTurn()
        {
            // choice between inventory, attack or party change

            if (_choiceIndex == 0)
            {
                //choose skill
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
