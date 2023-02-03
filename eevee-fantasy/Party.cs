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

        public static bool Swap(Character pokemon, Character pokemon2)

        {
            bool swapped = false;
            if (pokemon != null && pokemon2 != null)
            {
                swapped = true;
                int temp = pokemon.Id;
                int index = BattlePartyMembers.IndexOf(temp);
                int index2 = BattlePartyMembers.IndexOf(pokemon2.Id);
                BattlePartyMembers[index] = pokemon2.Id;
                BattlePartyMembers[index2] = temp;
            }
            return swapped;
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
            int myChoice =150;
            do
            {
                myChoice = Choice();
                if(myChoice == -1)
                {
                    Close();
                    return null;
                }
            } while(PartyMembers[BattlePartyMembers[myChoice]].Alive == false);

            Close();
            //Console.WriteLine(Party.PartyMembers[Party.BattlePartyMembers[myChoice]].Name);
            return PartyMembers[BattlePartyMembers[myChoice]];
        }

        public static Character ChoosePokemonObject()
        {
            Open();
            //BattleMap.AddCursor(1, 2);
            Console.SetCursorPosition(1, 2);
            int myChoice = 150;

                myChoice = Choice();
                if (myChoice == -1)
                {
                    Close();
                    return null;
                }


            Close();
            //Console.WriteLine(Party.PartyMembers[Party.BattlePartyMembers[myChoice]].Name);
            return PartyMembers[BattlePartyMembers[myChoice]];
        }

        private static int Choice()
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
                        PartyMenu.MoveCursor(input.KeyChar, BattlePartyMembers.Count());
                    }
                    else if ((input.Key == ConsoleKey.DownArrow || input.KeyChar == 's') && Index < BattlePartyMembers.Count())//var to check skill unlocked
                    {
                        Index += 1;
                        PartyMenu.MoveCursor(input.KeyChar, BattlePartyMembers.Count());
                    }
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    
                    return Index;
                    _choiceDone = true;
                }
                if (input.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("hahahaa");
                    Close();
                    Index = -1;
                    break;
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
