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
        public BasicEnemy()
        {
            TotalHp = 100;
            TotalDef = 65;
            TotalAtk = 40;
            Speed = 100; // random 100 -> 110;

            giveAttribute();
            for (int i = 0; i < 40; i++) //remplacer 5 par un rand
            {
                LevelUp();
            }

        }

        public void giveAttribute()
        {
            Random rnd = new Random();
            int indexChoice = rnd.Next(1, 7);

            switch (indexChoice)
            {
                case 1:
                    Console.WriteLine("My enemy is normal");
                    Attribute = new Normal();
                    break;
                case 2:
                    Console.WriteLine("My enemy is Fire");
                    Attribute = new Fire();
                    break;
                case 3:
                    Console.WriteLine("My enemy is Water");
                    Attribute = new Water();
                    break;
                case 4:
                    Console.WriteLine("My enemy is Thunder");
                    Attribute = new Thunder();
                    break;
                case 5:
                    Console.WriteLine("My enemy is Plant");
                    Attribute = new Plant();
                    break;
                case 6:
                    Console.WriteLine("My enemy is Ice");
                    Attribute = new Ice();
                    break;
                default:
                    break;
            }
        }
    }
}
