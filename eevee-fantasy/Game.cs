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
        public static int PositionX { get; set; }
        public static int PositionY { get; set; }
        public static int Flareon { get; set; }
        public static int Vaporeon { get; set; }
        public static int Jolteon { get; set; }
        public static int Leafeon { get; set; }
        public static int Glaceon { get; set; }

        public static void Init()
        {
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
                        string setting = line.Split("=")[0];
                        int value = Int32.Parse(line.Split("=")[1]);

                        switch (setting)
                        {
                            case "GameLevel":
                                GameLevel = value;
                                break;
                            case "PositionX":
                                    PositionX = value;
                                break;
                            case "PositionY":
                                PositionY = value;
                                break;
                            case "Flareon":
                                Flareon = value;
                                break;
                            case "Vaporeon":
                                Vaporeon = value;
                                break;
                            case "Jolteon":
                                Jolteon = value;
                                break;
                            case "Leafeon":
                                Leafeon = value;
                                break;
                            case "Glaceon":
                                Glaceon = value;
                                break;
                            default:
                                break;
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
                save.Write("GameLevel=0\nPositionX=0\nPositionY=0\nFlareon=0\nVaporeon=0\nJolteon=0\nLeafeon=0\nGlaceon=0");
            }
        }
    }
}
