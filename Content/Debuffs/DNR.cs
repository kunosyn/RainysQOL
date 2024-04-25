using Microsoft.CodeAnalysis.Host;
using RainysQOL.ModPlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace RainysQOL.Content.Debuffs
{
    public class DNR : ModBuff
    {
        public override string Texture => RainysQOL.AssetPath + "Debuffs/DNR";

        public const int DurationStandard = 60 * 60;

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}
