using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainysQOL.Configs;
using RainysQOL.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RainysQOL.Content.Items.Accessories
{
    public class SummonersController : ModItem
    {
        public override string Texture => RainysQOL.AssetPath + "Textures/Accessories/SummonersController";

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Radar);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!RainysQOL.serverConfig.SummonersControllerEnabled) return;
            player.GetModPlayer<BuffsPlayer>().ConsumableExtraSpeed = true;
        }


        public override void AddRecipes()
        {
            if (RainysQOL.serverConfig.SummonersControllerEnabled)
            {
                CreateRecipe()
                    .AddIngredient(ItemID.ChlorophyteBar, stack: 12)
                    .AddIngredient(ItemID.ShroomiteBar, stack: 12)
                    .AddIngredient(ItemID.SpectreBar, stack: 12)
                    .AddIngredient(ItemID.BeetleHusk, stack: 5)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
}
