﻿using System;
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

        public static void Init(Eevee eevee)
        {
            if (!GetSave(eevee))
            {
                CreateSave(eevee);
            }
        }

        private static bool GetSave(Eevee eevee)
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
                                eevee.X = value;
                                break;
                            case "PositionY":
                                eevee.Y = value;
                                break;
                            case "Flareon":
                                Party.PartyMembers![0].Recruited = Convert.ToBoolean(value);
                                break;
                            case "FlareonHp":
                                Party.PartyMembers![0].BattleHp = value;
                                break;
                            case "Vaporeon":
                                Party.PartyMembers![1].Recruited = Convert.ToBoolean(value);
                                break;
                            case "VaporeonHp":
                                Party.PartyMembers![1].BattleHp = value;
                                break;
                            case "Jolteon":
                                Party.PartyMembers![2].Recruited = Convert.ToBoolean(value);
                                break;
                            case "JolteonHp":
                                Party.PartyMembers![2].BattleHp = value;
                                break;
                            case "Leafeon":
                                Party.PartyMembers![3].Recruited = Convert.ToBoolean(value);
                                break;
                            case "LeafeonHp":
                                Party.PartyMembers![3].BattleHp = value;
                                break;
                            case "Glaceon":
                                Party.PartyMembers![4].Recruited = Convert.ToBoolean(value);
                                break;
                            case "GlaceonHp":
                                Party.PartyMembers![4].BattleHp = value;
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

        public static void CreateSave(Eevee eevee)
        {
            //Création du fichier texte de sauvegarde -- "false" permet de remplacer le texte déjà présent
            using (StreamWriter save = new StreamWriter("save.txt", false))
            {
                string str = "GameLevel=" + GameLevel.ToString() +
                    "\nPositionX=" + eevee.X.ToString() +
                    "\nPositionY=" + eevee.Y.ToString() +
                    "\nFlareon=" + Convert.ToInt64(Party.PartyMembers![0].Recruited).ToString() +
                    "\nFlareonHp=" + Party.PartyMembers![0].BattleHp.ToString() +
                    "\nVaporeon=" + Convert.ToInt64(Party.PartyMembers![1].Recruited).ToString() +
                    "\nVaporeonHp=" + Party.PartyMembers![1].BattleHp.ToString() +
                    "\nJolteon=" + Convert.ToInt64(Party.PartyMembers![2].Recruited).ToString() +
                    "\nJolteonHp=" + Party.PartyMembers![2].BattleHp.ToString() +
                    "\nLeafeon=" + Convert.ToInt64(Party.PartyMembers![3].Recruited).ToString() +
                    "\nLeafeonHp=" + Party.PartyMembers![3].BattleHp.ToString() +
                    "\nGlaceon=" + Convert.ToInt64(Party.PartyMembers![4].Recruited).ToString() +
                    "\nGlaceonHp=" + Party.PartyMembers![4].BattleHp.ToString();

                save.Write(str);
            }
        }
    }
}