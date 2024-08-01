using System;
using Terraria;
using Terraria.ModLoader;

namespace BossesGiveRandomDebuffs
{

    public class BGRDGlobalNPC : GlobalNPC
    {
        public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo hurtInfo)
        {
            //check if the current npc is a boss
            if (npc.boss)
            {
                //get a random buff from the list
                int randomBuffID = Main.rand.Next(1, BGRDSystem.debuffs.Count - 1);

                //clamp the random buff id just in case
                randomBuffID = Math.Clamp(randomBuffID, 1, BGRDSystem.debuffs.Count - 1);

                //grab the random buff from the allowed list
                randomBuffID = BGRDSystem.debuffs[randomBuffID];

                //apply the buff
                target.AddBuff(randomBuffID, Main.rand.Next(ffFunc.TimeToTick(5), ffFunc.TimeToTick(0, 2)));
            }

            base.OnHitPlayer(npc, target, hurtInfo);
        }
    }
}
