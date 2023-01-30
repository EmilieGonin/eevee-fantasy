using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Party
    {
        public List<Character>? PartyMembers;

        public Party()
        {
            PartyMembers= new List<Character>();
        }


        public void AddMember(Character member)
        {
            PartyMembers.Add(member);
        }
    }
}
