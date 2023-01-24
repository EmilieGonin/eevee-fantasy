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
        public int GameLevel { get; set; }

        public Game()
        {
            GameLevel = 0;

            //Création du fichier texte de sauvegarde
            using (StreamWriter save = new StreamWriter("save.txt"))
            {
                save.WriteLine("test");
            }

            //Lecture du fichier texte de sauvegarde
            using (StreamReader save = new StreamReader("save.txt"))
            {
                save.ReadLine();
            }
        }
    }
}
