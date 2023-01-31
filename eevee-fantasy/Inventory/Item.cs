using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class Item
    {
        public string? Name { get; set; }
        public int Number { get; set; }
        public int Price { get; protected set; }

        public virtual void Use(Character character)
        {
            this.Number--;
        }
    }
}
