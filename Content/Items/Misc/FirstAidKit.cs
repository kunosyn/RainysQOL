using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RainysQOL.Content.Items.Misc
{
    public class FirstAidKit : ModItem
    {
        public override string Texture => RainysQOL.AssetPath + "Textures/Items/Misc/FirstAidKit";

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.LightRed;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, stack: 5)
                .AddIngredient(ItemID.SoulofFright, stack: 15)
                .AddIngredient(ItemID.SoulofSight, stack: 15)
                .AddIngredient(ItemID.SoulofMight, stack: 15)
                .AddIngredient(ItemID.LifeCrystal, stack: 20)
                .AddTile(TileID.MythrilAnvil)
                .AddCondition(Condition.NearWater)
                .Register();

        }
    }
}