using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace BossesGiveRandomDebuffs
{
    internal class BGRDGlobalProjectile : GlobalProjectile
    {
        //function that runs whenever the projectile touch a player
        public override void OnHitPlayer(Projectile projectile, Player target, Player.HurtInfo info)
        {
            //check if the current projectile is a boss projectile is it's allowed to give the debuff
            if (ffVar.Bosses.BossProjectiles.Contains(projectile.type) && BGRDConfig.Instance.BossProjectiles)
            {
                //give the player a random debuff
                BossesGiveRandomDebuffs.GiveRandomDebuff(target);
            }
             
            base.OnHitPlayer(projectile, target, info);
        }
    }
}
