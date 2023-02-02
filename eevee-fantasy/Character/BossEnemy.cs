using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
	public class BossEnemy : Character
	{
		public BossEnemy()
		{
            XpGain = 300;
		}

		public void giveBestAttribute()
		{
			Character temp = null;
			int attributeIndex;

            for (int i = 0; i < Party.BattlePartyMembers.Count(); i++)
			{
				if (temp == null ) 
				{ 
					temp = Party.PartyMembers[Party.BattlePartyMembers[i]];
				}
				else if (Party.PartyMembers[Party.BattlePartyMembers[i]].lvl > temp.lvl)
				{
					temp = Party.PartyMembers[Party.BattlePartyMembers[i]];
                }
			}

			Random rnd = new Random();

			if(temp.Attribute.Weaknesses != null  )
			{
                giveAttribute(temp.Attribute.Weaknesses[rnd.Next(0, temp.Attribute.Weaknesses.Length - 1)]);
            }
			else if(temp.Attribute.Strengths != null)
			{
				do
				{
					attributeIndex = rnd.Next(1, 6);
				} while (temp.Attribute.Strengths.Contains(attributeIndex));
				giveAttribute(attributeIndex);
            }
			else
			{
                attributeIndex = rnd.Next(1, 6);
                giveAttribute(attributeIndex);
            }
		}
	}
}

