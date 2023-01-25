using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Character
    {

        
	   
        protected int totalHp, totalDef, totalMagicDef, totalAtk, totalPhysicalBonus, totalMagicalBonus, totalCritRate, totalCritDamage;
        protected int battleHp;

        protected bool dmgType; // 0 physical, 1 magical


        Character() {

            totalHp = 0;
            totalDef = 0;
            totalAtk = 0;
            totalCritRate = 0;
            totalCritDamage = 0;
            battleHp = totalHp;

        }
         ~Character() { }


        int Speed (Attr)
        public int GetBattleHP();
        public int GetDamageType();

    }
}
