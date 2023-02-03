using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Potion : Item
	{
        protected int Health { get; set; }

        public Potion()
		{
			Name = "Potion";
			Price = 10;
            Health = 40;
			Number = 3;
		}

        public override void Use(Character character)
		{
            if (character != null)
            {
                base.Use(character);
                if (character.BattleHp != character.TotalHp)
                {
                    int amountToGet = character.TotalHp - character.BattleHp;
                    character.BattleHp += Health;
                    new Dialogue("Vous avez utilisé une " + Name);

                    if (character.BattleHp > character.TotalHp)
                    {
                        new Dialogue(character.Name + " a récupéré " + amountToGet + " PV");
                        character.BattleHp = character.TotalHp;
                    }
                    else
                    {
                        new Dialogue(character.Name + " a récupéré " + Health);
                    }
                }
                else
                {
                    new Dialogue("Cela n'a aucun effet");
                }
            }
			
		
		}
    }
}

