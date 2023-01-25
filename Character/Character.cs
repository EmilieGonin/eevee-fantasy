using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Character
    {


        
        public string? Name { get; protected set; }
        public Skill[]? Skills { get; }
        public Attribute? Attribute { get; }

        public int TotalHp { get; protected set; }
        public int TotalDef { get; protected set; }
        public int TotalMagicDef { get; protected set; }
        public int TotalAtk { get; protected set; }
        public int BattleHp { get; protected set; }
        public int Speed { get; protected set; }

        public Character()
        {
            TotalHp = TotalDef = TotalAtk = BattleHp = 0;
        }

        public void unlockSkill()
        {
            //
        }

        public void LooseHp(int amount)
        {
            BattleHp -= amount;
        }
    }
}
