using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace BossesGiveRandomDebuffs
{
    internal class BGRDConfig : ModConfig
    {
        //tell the mod that the configs are on the server and logistical side of the mod. 
        public override ConfigScope Mode => ConfigScope.ServerSide;

        //define the instance for the mod
        public static BGRDConfig Instance;

        //display the general options line 
        [Header("$Mods.RandomBuffsMod.Configs.GeneralOptions")]

        //define the config value for boss minions giving debuffs
        [DefaultValue(true)]
        public bool BossMinions;

        //define the config value for the chance of getting the debuff
        [DefaultValue(50)]
        [Slider()]
        [Range(0, 100)]
        public int DebuffChance;

        //define the config value for boss minions giving debuffs
        [DefaultValue(5)]
        [Range(0, 99999)]
        public int DebuffTimeMin;

        //define the config value for boss minions giving debuffs
        [DefaultValue(120)]
        [Range(0, 99999)]
        public int DebuffTimeMax;
    }
}
