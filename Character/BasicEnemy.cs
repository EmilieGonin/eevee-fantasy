using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class BasicEnemy : Character
    {

        public BasicEnemy() 
        {
            TotalHp = 100;
            TotalDef = 25;
            TotalAtk = 50;
            Speed = 100;

        }
        //Création des ennemis de façon aléatoire dans la classe Battle
    }
}
