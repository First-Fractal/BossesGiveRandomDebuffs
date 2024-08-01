using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BossesGiveRandomDebuffs
{

    public class BGRDGlobalNPC : GlobalNPC
    {
        public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo hurtInfo)
        {
            //check if the current npc is a boss or a boss part or a boss minion if allowed
            if (npc.boss || ffVar.Bosses.BossParts.Contains(npc.type) || (BGRDConfig.Instance.BossMinions && ffVar.Bosses.BossMinions.Contains(npc.type)))
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
                        if (! BGRDConfig.Instance.BuffBlocklist.Contains(randomBuffID)) correctDebuff = true;
                    }

                    //apply the buff
                    target.AddBuff(randomBuffID, Main.rand.Next(ffFunc.TimeToTick(BGRDConfig.Instance.DebuffTimeMin), ffFunc.TimeToTick(BGRDConfig.Instance.DebuffTimeMax)));
                }
            }

            base.OnHitPlayer(npc, target, hurtInfo);
        }
    }
}
