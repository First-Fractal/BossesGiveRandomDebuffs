using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BossesGiveRandomDebuffs
{
	public class BossesGiveRandomDebuffs : Mod 
	{ 
        //function to give the player a random debuff
		public static void GiveRandomDebuff(Player target)
		{
            //make it have a 50% chance to apply it
            if (Main.rand.Next(0, 101) <= BGRDConfig.Instance.DebuffChance)
            {
                //bool to check if the current buff isnt a blacklist
                bool correctDebuff = false;
                //get a random buff from the list
                int randomBuffID = BuffID.Poisoned;

                //loop until you get a random debuff that isnt blacklisted
                while (!correctDebuff)
                {
                    //get a random buff from the list
                    randomBuffID = Main.rand.Next(1, BGRDSystem.debuffs.Count - 1);

                    //clamp the random buff id just in case
                    randomBuffID = Math.Clamp(randomBuffID, 1, BGRDSystem.debuffs.Count - 1);

                    //grab the random buff from the allowed list
                    randomBuffID = BGRDSystem.debuffs[randomBuffID];

                    //check to see if the buff id isnt in the blacklist, and stop the loop
                    if (!BGRDConfig.Instance.BuffBlocklist.Contains(randomBuffID)) correctDebuff = true;
                }

                //apply the buff
                target.AddBuff(randomBuffID, Main.rand.Next(ffFunc.TimeToTick(BGRDConfig.Instance.DebuffTimeMin), ffFunc.TimeToTick(BGRDConfig.Instance.DebuffTimeMax)));
            }
        }
	}
}
