using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace eevee_fantasy
{
    internal class Game
    {
        protected int level;
        public Game() {
            level = 0;

            using (StreamWriter save = new StreamWriter("save.txt"))
            {
                save.WriteLine("test");
            }

            using (StreamReader save = new StreamReader("save.txt"))
            {
                save.ReadLine();
            }
        }
        public int Level { get; set; }
    }
}
