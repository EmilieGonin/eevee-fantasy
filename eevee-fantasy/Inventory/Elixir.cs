using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Elixir : Item
    {
        public Elixir()
        {
            Name = "Elixir";
            Price = 50;
        }

        public override void Use(Character character)
        {
         
            new Dialogue("Not yet implemented");
            //Select skill
        }
    }
}
