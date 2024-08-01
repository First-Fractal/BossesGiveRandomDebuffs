using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BossesGiveRandomDebuffs
{
    internal class BGRDGlobalBuff : GlobalBuff
    {
         public override void Update(int type, Player player, ref int buffIndex)
        {
            //disable the longer expert mode debuff
            BuffID.Sets.LongerExpertDebuff[type] = false;

            //put the timer on all buffs
            Array.Fill(Main.buffNoTimeDisplay, false);

            //do vanilla functions
            base.Update(type, player, ref buffIndex);
        }

        //add in text to the tooltip of the buff to say the source of the mod
        public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
        {
            string buffSource = Language.GetTextValue("Mods.BossesGiveRandomDebuffs.BuffInfo.Vanilla");

            //if the buff ID is above the vanilla buff count, then its modded
            if (type > BuffID.Count)
            {
                buffSource = Language.GetTextValue("Mods.BossesGiveRandomDebuffs.BuffInfo.Modded");
            }
            //format the text
            string buff =  Language.GetTextValue("Mods.BossesGiveRandomDebuffs.BuffInfo.Message", buffSource);

            //color code the text and apply it to the tooltip
            tip += "\n[c/327DFF:" + buff + "]";

            base.ModifyBuffText(type, ref buffName, ref tip, ref rare);
        }
    }
}
