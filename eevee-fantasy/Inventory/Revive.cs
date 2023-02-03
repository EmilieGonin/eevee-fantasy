using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Revive : Item
    {
        public Revive()
        {
            Name = "Revive";
            Price = 70;
        }

        public override void Use(Character character)
        {

            if (character != null)
            {
                if (character.Alive == false)
                {
                    character.Alive = true;
                    character.BattleHp = character.TotalHp;
                    new Dialogue(character.Name + " got revived !");
                    base.Use(character);
                }
                else
                {
                    new Dialogue("Can't use");
                }
            }
        }
    }
}

