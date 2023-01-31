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
            BattlePartyMembers = PartyMembers;
            Console.WriteLine("haha" + PartyMembers[0].BattleHp);
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
            BattlePartyMembers[pokemon1.Id] = pokemon2;
            BattlePartyMembers[pokemon2.Id] = temp;

        }
    }
}
