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
			Price = 10;
            Health = 40;
		}

        public override void Use(Character character)
		{
			base.Use(character);
			character.BattleHp += Health;
		}

		
    }
}

