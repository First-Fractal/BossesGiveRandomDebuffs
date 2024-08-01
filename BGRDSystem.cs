using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace BossesGiveRandomDebuffs
{
    internal class BGRDSystem : ModSystem
    {
        //create a list of all the buffs that's loaded
        public static List<int> debuffs = new List<int>();

        public override void OnWorldLoad()
        {
            //clear the list
            debuffs = new List<int>();

            //get a list of all buffs loaded
            for (int i = 0; i <= BuffLoader.BuffCount - 1; i++)
            {
                //if the current buffID is a debuff, then add it
                if (Main.debuff[i] == true || Main.pvpBuff[i] == true) debuffs.Add(i);
            }
                base.OnWorldLoad();
        }
    }
}
