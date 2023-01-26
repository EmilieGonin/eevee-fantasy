using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class Character
    {


        
        public string? Name { get; protected set; }
        public Skill[]? Skills { get; }
        public Attribute? Attribute { get; }


        public int TotalXP { get; protected set; }
        public int XPToGet { get; protected set; }

        public int TotalHp { get; protected set; }
        public int TotalDef { get; protected set; }
        public int TotalMagicDef { get; protected set; }
        public int TotalAtk { get; set; }
        public int BattleHp { get; set; }
        public int Speed { get; protected set; }
        public bool Alive { get; protected set; }

        public Character()
        {
            TotalHp = TotalDef = TotalAtk = BattleHp = 0;
            Alive = true;
        }

        public void unlockSkill()
        {
            //
        }

        public void LooseHp(int amount)
        {
            BattleHp -= amount;
            if (BattleHp < 0)
            {
                Alive = false;
                BattleHp = 0;
            }
        }
    }
}
