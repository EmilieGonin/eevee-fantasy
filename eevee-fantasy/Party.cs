using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public static class Party
    {
        public static bool IsOpen { get; private set; }
        public static List<Character>? PartyMembers;
        public static List<int>? BattlePartyMembers;
        public static Menu PartyMenu { get; private set; }

        public static void Fill(Eevee eevee)
        {
            PartyMembers = new List<Character> { eevee, new Flareon(), new Vaporeon(), new Jolteon(), new Leafeon(), new Glaceon() };
            BattlePartyMembers = new List<int> { 0, };
          
        }

        public static void Recruit(int id)
        {
            PartyMembers[id].Recruited = true;
            BattlePartyMembers.Add(PartyMembers[id].Id);

        }

        public static void Swap(Character pokemon, Character pokemon2)

        {
            int temp = pokemon.Id;
            int index = BattlePartyMembers.IndexOf(temp);
            int index2 = BattlePartyMembers.IndexOf(pokemon2.Id);
            BattlePartyMembers[index] = pokemon2.Id;
            BattlePartyMembers[index2] = temp;
        }

        public static int GetNumberRecruited()
        {
            int number = 0;
            for(int i = 0; i < BattlePartyMembers.Count; i++) 
            {
                number++;
            }
            return number;
        }

        public static void Open()
        {
            IsOpen = true;
            PartyMenu = new Menu();
            PartyMenu.DrawListPokemon(PartyMembers, BattlePartyMembers);
            PartyMenu.AddCursor(1, 2);
        }


        public static Character ChoosePokemon()
        {
            Open();
            //BattleMap.AddCursor(1, 2);
            Console.SetCursorPosition(1, 2);
            int myChoice = 0;
            do
            {
                myChoice = Choice(BattlePartyMembers.Count() - 1);
            } while (PartyMembers[BattlePartyMembers[myChoice]].Alive == false);

            Close();
            //Console.WriteLine(Party.PartyMembers[Party.BattlePartyMembers[myChoice]].Name);
            return PartyMembers[BattlePartyMembers[myChoice]];
        }


        private static int Choice(int choiceLimit)
        {
         
            int Index = 0;
            bool  _choiceDone = false;
            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.UpArrow || input.Key == ConsoleKey.DownArrow || input.KeyChar == 'z' || input.KeyChar == 's')
                {

                    if ((input.Key == ConsoleKey.UpArrow || input.KeyChar == 'z') && Index > 0)
                    {
                        Index -= 1;
                        PartyMenu.MoveCursor(input.KeyChar, choiceLimit + 1);
                    }
                    else if ((input.Key == ConsoleKey.DownArrow || input.KeyChar == 's') && Index < choiceLimit)//var to check skill unlocked
                    {
                        Index += 1;
                        PartyMenu.MoveCursor(input.KeyChar, choiceLimit + 1);
                    }
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    _choiceDone = true;
                }
            } while (_choiceDone == false);

            return Index;
        }

        public static void Close()
        {
            IsOpen = false;
        }
    }
}
