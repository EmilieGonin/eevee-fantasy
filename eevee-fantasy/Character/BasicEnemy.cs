using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class BasicEnemy : Character
    {
        //Création des ennemis de façon aléatoire dans la classe Battle
        public BasicEnemy(int level, int attribute)
        {
            BaseHp = 65;
            BaseDef = 50;
            BaseAtk = 75;
            Speed = 100; // random 100 -> 110;
            XpGain = 100;
            giveAttribute(attribute);

            for (int i = 0; i < level; i++)
            {
                LevelUp();
            }
        }
    }
}
