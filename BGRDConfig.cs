using System;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ID;
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

        //define the config value for boss projectiles giving debuffs
        [DefaultValue(true)]
        public bool BossProjectiles;

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
        [DefaultValue(90)]
        [Range(0, 99999)]
        public int DebuffTimeMax;

        //define the list of buffs that should be blocked
        public HashSet<int> BuffBlocklist = new()
        {
            BuffID.Werewolf, BuffID.Merfolk, BuffID.Campfire, BuffID.HeartLamp, BuffID.Wet, BuffID.Lovestruck, 
            BuffID.Stinky, BuffID.Slimed, BuffID.Sunflower, BuffID.MonsterBanner, BuffID.CatBast, BuffID.GelBalloonBuff, BuffID.BrainOfConfusionBuff, BuffID.NeutralHunger
        };
    }
}
