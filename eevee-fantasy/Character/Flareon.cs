using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Flareon : Character
    {
        public Flareon()
        {
            Sprite = 'F';
            Color = ConsoleColor.Red;

            Friend_X = 5;
            Friend_Y = 18;
        }
    }
}
