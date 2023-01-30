using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class BasicEnemy : Character
    {
        //Création des ennemis de façon aléatoire dans la classe Battle
        public BasicEnemy()
        {
            TotalHp = 100;
            TotalDef = 25;
            TotalAtk = 50;
            Speed = 100; // random 100 -> 110;

            for (int i = 0; i < 5; i++) //remplacer 5 par un rand
            {
                LevelUp();
            }

        }
    }
}
