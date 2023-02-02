using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Security;
using System.Text.Json;

namespace eevee_fantasy
{
    internal static class Game
    {
        public static int GameLevel { get; set; }

        public static Eevee Init(Eevee eevee)
        {
            Eevee savedEevee = GetSave(eevee);

            if (savedEevee == null)
            {
                CreateSave(eevee);
                return eevee;
            }
            else
            {
                return savedEevee;
            }
        }

        private static Eevee GetSave(Eevee eevee)
        {
            try
            {
                //Lecture du fichier texte de sauvegarde
                using (StreamReader save = new StreamReader("save.txt"))
                {
                    string? line = null;

                    while (!save.EndOfStream)
                    {
                        line = save.ReadLine();
                        string setting = line.Split("=")[0];
                        string value = line.Split("=")[1];

                        switch (setting)
                        {
                            case "Eevee":
                                eevee = JsonSerializer.Deserialize<Eevee>(value);
                                break;
                            case "Party":
                                Party.BattlePartyMembers = JsonSerializer.Deserialize<List<int>>(value);
                                break;
                            case "Bosses":
                                Bosses.BossesToBeat = JsonSerializer.Deserialize<List<BossEnemy>>(value);
                                break;
                            case "Inventory":
                                Inventory.Items = JsonSerializer.Deserialize<Item[]>(value);
                                break;
                            case "GameLevel":
                                GameLevel = Int32.Parse(value);
                                break;
                        }
                    }
                }
                return eevee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static void CreateSave(Eevee eevee)
        {
            //Création du fichier texte de sauvegarde -- "false" permet de remplacer le texte déjà présent
            string eeveeJson = JsonSerializer.Serialize(eevee);
            string partyJson = JsonSerializer.Serialize(Party.BattlePartyMembers);
            string bossesJson = JsonSerializer.Serialize(Bosses.BossesToBeat);
            string inventoryJson = JsonSerializer.Serialize(Inventory.Items);

            StringBuilder json = new StringBuilder("Eevee=");
            json.Append(eeveeJson);
            json.AppendLine();
            json.Append("Party=");
            json.Append(partyJson);
            json.AppendLine();
            json.Append("Bosses=");
            json.Append(bossesJson);
            json.AppendLine();
            json.Append("Inventory=");
            json.Append(inventoryJson);
            json.AppendLine();
            json.Append("GameLevel=");
            json.Append(GameLevel);

            using (StreamWriter save = new StreamWriter("save.txt", false))
            {
                save.Write(json);
            }
        }

        public static void DeleteSave()
        {
            //Création du fichier texte de sauvegarde -- "false" permet de remplacer le texte déjà présent
            using (StreamWriter save = new StreamWriter("save.txt", false))
            {
                string str = "GameLevel=0" +
                    "\nPositionX=0" +
                    "\nPositionY=0" +
                    "\nEevee=1" +
                    "\nEeveeHp=" + Party.PartyMembers![0].BattleHp.ToString() +
                    "\nFlareon=0" +
                    "\nFlareonHp=" + Party.PartyMembers![1].BattleHp.ToString() +
                    "\nVaporeon=0" +
                    "\nVaporeonHp=" + Party.PartyMembers![2].BattleHp.ToString() +
                    "\nJolteon=0" +
                    "\nJolteonHp=" + Party.PartyMembers![3].BattleHp.ToString() +
                    "\nLeafeon=0" +
                    "\nLeafeonHp=" + Party.PartyMembers![4].BattleHp.ToString() +
                    "\nGlaceon=0" +
                    "\nGlaceonHp=" + Party.PartyMembers![5].BattleHp.ToString();

                save.Write(str);
            }
        }
    }
}