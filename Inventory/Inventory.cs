using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
	internal class Inventory
	{
        public int Id { get; protected set; }
        public int Price { get; protected set; }
        public int PokeDollars { get; private set; }
        public Revive[]? Revives { get; }
        public AtkPotion[]? AtkPotions { get; }
        public Elixir[]? Elixir { get; }
        public Potion[]? HealthPotions { get; }
        public SuperPotion[]? SuperPotions { get; }
        public HyperPotion[]? HyperPotions { get; }

        //1 = Potion, 2 = SuperPotion, 3 = HyperPotion
        //4 = AtkPotion, 5 = Elixir, 6 = Revive
        //Création d'un enum ?
        public void Buy(int id)
        {
            //
        }
    }

    
}

