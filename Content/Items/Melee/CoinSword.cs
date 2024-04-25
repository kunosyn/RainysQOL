using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RainysQOL.Content.Items.Melee
{
    public class CoinSword : ModItem
    {
        public override string Texture => RainysQOL.AssetPath + "Textures/Items/Melee/CoinSword";

        public override void SetDefaults()
        {
            Item.damage = 75;
            Item.DamageType = DamageClass.Melee;
            Item.width = 30;
            Item.height = 30;
            Item.scale = 3.4f;

            Item.useTime = 18;
            Item.useAnimation = 18;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 2000000;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
        }
    }
}