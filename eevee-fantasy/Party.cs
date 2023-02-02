﻿using System;
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
        public static List<Character>? BattlePartyMembers;
        public static Menu PartyMenu { get; private set; }

        public static void Fill(Eevee eevee)
        {
            PartyMembers = new List<Character> { eevee, new Flareon(), new Vaporeon(), new Jolteon(), new Leafeon(), new Glaceon() };
            BattlePartyMembers = new List<Character> { eevee, };
          
        }

        public static void Recruit(int id)
        {
            PartyMembers[id].Recruited = true;
            BattlePartyMembers.Add(PartyMembers[id]);

        }

        public static void Swap(Character pokemon, Character pokemon2)

        {

            Character temp = BattlePartyMembers[pokemon.Id];
            BattlePartyMembers[pokemon.Id] = BattlePartyMembers[pokemon2.Id];
            BattlePartyMembers[pokemon2.Id] = temp;


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
            PartyMenu.DrawList(BattlePartyMembers);
            PartyMenu.AddCursor(1, 2);
        }

       
    }
}
