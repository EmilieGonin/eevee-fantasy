using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Security;

namespace eevee_fantasy
{
    internal static class Game
    {
        public static int GameLevel { get; set; }

        public static void Init()
        {
            GameLevel = 0;
            if (!GetSave())
            {
                CreateSave();
            }
        }

        private static bool GetSave()
        {
            try
            {
                //Lecture du fichier texte de sauvegarde
                using (StreamReader save = new StreamReader("save.txt"))
                {
                    string? line = null;

                    while ((line = save.ReadLine()) != null && !save.EndOfStream)
                    {
                        Console.WriteLine(line);
                        if (line.StartsWith("GameLevel"))
                        {
                            //Console.WriteLine("test");
                            GameLevel = Int32.Parse(line.Split("=")[1]);
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static void CreateSave()
        {
            //Création du fichier texte de sauvegarde
            using (StreamWriter save = new StreamWriter("save.txt"))
            {
                save.Write("GameLevel=0\nPosition=(0,0)\nFlareon=0\nVaporeon=0\nJolteon=0\nLeafeon=0\nGlaceon=0");
            }
        }
    }
}
