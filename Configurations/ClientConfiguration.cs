using RainysQOL.Content.AccessorySlots;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace RainysQOL.Configs
{
    [BackgroundColor(99, 69, 122)]
    public class ClientConfiguration : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        #region utility

        [Header("Utility")]

        [DefaultValue(true)]
        [BackgroundColor(191, 140, 230)]
        public bool QuickDiscordSafeWarp;

        #endregion
    }
}
