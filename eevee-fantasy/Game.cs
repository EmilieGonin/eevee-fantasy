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
                        string[] values = value.Split("#");

                        switch (setting)
                        {
                            case "Party":
                                Party.PartyMembers[0] = JsonSerializer.Deserialize<Eevee>(values[0]);
                                Party.PartyMembers[1] = JsonSerializer.Deserialize<Flareon>(values[1]);
                                Party.PartyMembers[2] = JsonSerializer.Deserialize<Vaporeon>(values[2]);
                                Party.PartyMembers[3] = JsonSerializer.Deserialize<Jolteon>(values[3]);
                                Party.PartyMembers[4] = JsonSerializer.Deserialize<Leafeon>(values[4]);
                                Party.PartyMembers[5] = JsonSerializer.Deserialize<Glaceon>(values[5]);
                                eevee = Party.PartyMembers[0] as Eevee;
                                break;
                            case "BattleParty":
                                Party.BattlePartyMembers = JsonSerializer.Deserialize<List<int>>(value);
                                break;
                            case "Bosses":
                                Bosses.BossesToBeat[0] = JsonSerializer.Deserialize<BossOne>(values[0]);
                                Bosses.BossesToBeat[1] = JsonSerializer.Deserialize<BossTwo>(values[1]);
                                Bosses.BossesToBeat[2] = JsonSerializer.Deserialize<BossThree>(values[2]);
                                Bosses.BossesToBeat[3] = JsonSerializer.Deserialize<BossFour>(values[3]);
                                Bosses.BossesToBeat[4] = JsonSerializer.Deserialize<BossFive>(values[4]);
                                break;
                            case "Inventory":
                                Inventory.Items[0] = JsonSerializer.Deserialize<AtkPotion>(values[0]);
                                Inventory.Items[1] = JsonSerializer.Deserialize<Elixir>(values[1]);
                                Inventory.Items[2] = JsonSerializer.Deserialize<Revive>(values[2]);
                                Inventory.Items[3] = JsonSerializer.Deserialize<Potion>(values[3]);
                                Inventory.Items[4] = JsonSerializer.Deserialize<SuperPotion>(values[4]);
                                Inventory.Items[5] = JsonSerializer.Deserialize<HyperPotion>(values[5]);
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
                //Console.WriteLine(e.Message);
                return null;
            }
        }

        public static void CreateSave(Eevee eevee)
        {
            //Création du fichier texte de sauvegarde -- "false" permet de remplacer le texte déjà présent

            StringBuilder json = new StringBuilder();
            json.Append("BattleParty=").Append(JsonSerializer.Serialize(Party.BattlePartyMembers)).AppendLine();
            json.Append("GameLevel=").Append(GameLevel).AppendLine();
            json.Append("Party=");

            foreach (var character in Party.PartyMembers)
            {
                json.Append(JsonSerializer.Serialize(character)).Append("#");
            }

            json.AppendLine().Append("Bosses=");

            foreach (var character in Bosses.BossesToBeat)
            {
                json.Append(JsonSerializer.Serialize(character)).Append("#");
            }

            json.AppendLine().Append("Inventory=");

            foreach (var item in Inventory.Items)
            {
                json.Append(JsonSerializer.Serialize(item)).Append("#");
            }

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