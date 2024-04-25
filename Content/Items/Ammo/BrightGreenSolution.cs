using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RainysQOL.Content.Items.Ammo
{
    public class BrightGreenSolution : ModItem
    {
        public override string Texture => RainysQOL.AssetPath + "Textures/Items/Ammo/BrightGreenSolution";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.DefaultToSolution(ModContent.ProjectileType<BrightGreenSolutionProjectile>());
            Item.value = Item.buyPrice(copper: 1000);
            Item.rare = ItemRarityID.Orange;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.Solutions;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(itemID: ItemID.GreenSolution, stack: 3)
                .AddIngredient(itemID: ItemID.Mushroom, stack: 15)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }

    public class BrightGreenSolutionProjectile : ModProjectile
    {
        public override string Texture => RainysQOL.AssetPath + "Textures/Projectiles/BrightGreenSolution";
        public ref float Progress => ref Projectile.ai[0];


        public override void SetDefaults()
        {
            Projectile.DefaultToSpray();
            Projectile.aiStyle = 0;
        }

        public override void AI()
        {
            int dustType = ModContent.DustType<Dusts.BrightGreenSolution>();

            if (Projectile.owner == Main.myPlayer)
            {
                Convert((int)(Projectile.position.X + (Projectile.width * 0.5f)) / 16, (int)(Projectile.position.Y + (Projectile.height * 0.5f)) / 16, 2);
            }

            if (Projectile.timeLeft > 133)
            {
                Projectile.timeLeft = 133;
            }

            if (Progress > 7f)
            {
                float dustScale = 1f;

                if (Progress == 8f)
                {
                    dustScale = 0.2f;
                }
                else if (Progress == 9f)
                {
                    dustScale = 0.4f;
                }
                else if (Progress == 10f)
                {
                    dustScale = 0.6f;
                }
                else if (Progress == 11f)
                {
                    dustScale = 0.8f;
                }

                Progress += 1f;


                var dust = Dust.NewDustDirect(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, dustType, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);

                dust.noGravity = true;
                dust.scale *= 1.75f;
                dust.velocity.X *= 2f;
                dust.velocity.Y *= 2f;
                dust.scale *= dustScale;
            }
            else
            {
                Progress += 1f;
            }

            Projectile.rotation += 0.3f * Projectile.direction;
        }

        private static void Convert(int i, int j, int size = 4)
        {
            for (int k = i - size; k <= i + size; k++)
            {
                for (int l = j - size; l <= j + size; l++)
                {
                    if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt((size * size) + (size * size)))
                    {
                        int type = Main.tile[k, l].TileType;
                        int wall = Main.tile[k, l].WallType;

                        if (wall != 0 && (WallID.Sets.Conversion.Dirt[wall] || WallID.Sets.Conversion.Grass[wall] || WallID.Sets.Conversion.HardenedSand[wall] || WallID.Sets.Conversion.Snow[wall]))
                        {
                            Main.tile[k, l].WallType = WallID.Dirt;

                            WorldGen.SquareWallFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }

                        if (TileID.Sets.Conversion.Dirt[type] || TileID.Sets.Conversion.Sand[type])
                        {
                            Main.tile[k, l].TileType = TileID.Dirt;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                        else if (type == TileID.Mud)
                        {
                            Main.tile[k, l].TileType = TileID.Dirt;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        } else if (type == TileID.JungleGrass || type == TileID.MushroomGrass || type == TileID.CrimsonGrass || type == TileID.CorruptGrass || type == TileID.HallowedGrass || type == TileID.AshGrass)
                        {
                            Main.tile[k, l].TileType = TileID.Grass;
                            WorldGen.SquareTileFrame(k, l);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                    }
                }
            }
        }
    }
}
