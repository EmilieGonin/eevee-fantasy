using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Security;

namespace eevee_fantasy
{
    internal class Game
    {
        int _gameLevel;
        public Game()
        {
            GameLevel = 0;
            Console.WriteLine("test");

            using (StreamWriter save = new StreamWriter("save.txt"))
            {
                save.WriteLine("test");
            }

            using (StreamReader save = new StreamReader("save.txt"))
            {
                save.ReadLine();
            }
        }

        public int GameLevel { get => _gameLevel; set => _gameLevel = value; }
    }
}
