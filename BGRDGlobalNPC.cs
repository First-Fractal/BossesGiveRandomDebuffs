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
            if 
                ((npc.boss || ffVar.Bosses.BossParts.Contains(npc.type)) || (BGRDConfig.Instance.BossMinions && ffVar.Bosses.BossMinions.Contains(npc.type) && ffFunc.IsBossAlive()))
            {
                //give the player a random debuff
                BossesGiveRandomDebuffs.GiveRandomDebuff(target);
            }

            base.OnHitPlayer(npc, target, hurtInfo);
        }
    }
}
