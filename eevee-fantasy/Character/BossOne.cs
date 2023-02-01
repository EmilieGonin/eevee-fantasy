using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
	public class BossOne : Character
	{
		public BossOne()
		{
			Id = 1;

			Enemy = 'B';
			Color = ConsoleColor.DarkRed;

            X = 62;
            Y = 8;
        }
	}
}

