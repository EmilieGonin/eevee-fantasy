using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public static class Party
    {
        public static List<Character>? PartyMembers;
        public static List<Character>? BattlePartyMembers;

        public static void Fill(Eevee eevee)
        {
            PartyMembers = new List<Character> { eevee, new Flareon(), new Vaporeon(), new Jolteon(), new Leafeon(), new Glaceon() };
            BattlePartyMembers = new List<Character> { eevee};
          
        }

        public static void Recruit(int id)
        {
            PartyMembers[id].Alive = true; 
            BattlePartyMembers.Add(PartyMembers[id]);

        }

        public static void ReplaceDeadPokemon(Character pokemon)
        {
            Character temp = BattlePartyMembers[0];
            BattlePartyMembers[0] = pokemon;
            BattlePartyMembers[pokemon.Id] = temp;
                
        }
        public static void Swap(Character pokemon1, Character pokemon2)
        
        {
            Character temp = BattlePartyMembers[pokemon1.Id];
            BattlePartyMembers[pokemon1.Id] = BattlePartyMembers[pokemon2.Id];
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

       
    }
}
