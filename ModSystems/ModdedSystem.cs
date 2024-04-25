using RainysQOL.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using RainysQOL;

namespace RainysQOL.ModSystems
{
    public class ModdedSystem : ModSystem
    {
        public override void AddRecipes()
        {
            if (RainysQOL.serverConfig.WarTableRecipe)
            {
                Recipe warTableRecipe = Recipe.Create(ItemID.WarTable, amount: 1)
                    .AddIngredient(ItemID.SoulofNight, stack: 15)
                    .AddIngredient(ItemID.SoulofLight, stack: 15)
                    .AddRecipeGroup(RecipeGroupID.Wood, stack: 10)
                    .AddRecipeGroup(RecipeGroupID.IronBar, stack: 25)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }


            if (RainysQOL.serverConfig.ClentaminatorRecipe)
            {
                Recipe clentaminatorRecipe = Recipe.Create(ItemID.Clentaminator, amount: 1)
                .AddIngredient(ItemID.PurificationPowder, stack: 300)
                .AddIngredient(ItemID.AdamantiteBar, stack: 15)
                .AddIngredient(ItemID.Wire, stack: 20)
                .AddTile(TileID.MythrilAnvil)
                .Register();

                Recipe clentaminatorRecipe2 = Recipe.Create(ItemID.Clentaminator, amount: 1)
                    .AddIngredient(ItemID.PurificationPowder, stack: 300)
                    .AddIngredient(ItemID.TitaniumBar, stack: 15)
                    .AddIngredient(ItemID.Wire, stack: 20)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }


            if (RainysQOL.serverConfig.GreenSolutionRecipe)
            {
                Recipe greenSolutionRecipe = Recipe.Create(ItemID.GreenSolution, amount: 3)
                .AddIngredient(ItemID.PurificationPowder, stack: 10)
                .AddIngredient(ItemID.Bottle, stack: 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            }

            if (RainysQOL.serverConfig.BlueSolutionRecipe)
            {
                Recipe blueSolutionRecipe = Recipe.Create(ItemID.BlueSolution, amount: 3)
                    .AddIngredient(ItemID.HallowedSeeds, stack: 10)
                    .AddIngredient(ItemID.GreenSolution, stack: 10)
                    .AddIngredient(ItemID.Bottle, stack: 3)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }

            if (RainysQOL.serverConfig.DarkBlueSolutionRecipe)
            {
                Recipe darkBlueSolutionRecipe = Recipe.Create(ItemID.DarkBlueSolution, amount: 3)
                    .AddIngredient(ItemID.MushroomGrassSeeds, stack: 10)
                    .AddIngredient(ItemID.GreenSolution, stack: 3)
                    .AddIngredient(ItemID.Bottle, stack: 3)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }

            if (RainysQOL.serverConfig.YellowSolutionRecipe)
            {
                Recipe yellowSolutionRecipe = Recipe.Create(ItemID.SandSolution, amount: 3)
                    .AddIngredient(ItemID.Cactus, stack: 10)
                    .AddIngredient(ItemID.GreenSolution, stack: 3)
                    .AddIngredient(ItemID.Bottle, stack: 3)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }

            if (RainysQOL.serverConfig.WhiteSolutionRecipe)
            {
                Recipe whiteSolutionRecipe = Recipe.Create(ItemID.SnowSolution, amount: 3)
                    .AddIngredient(ItemID.Shiverthorn, stack: 10)
                    .AddIngredient(ItemID.GreenSolution, stack: 3)
                    .AddIngredient(ItemID.Bottle, stack: 3)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }

            if (RainysQOL.serverConfig.EvilSolutionsRecipes)
            {
                Recipe redSoultionRecipe = Recipe.Create(ItemID.RedSolution, amount: 3)
                    .AddIngredient(ItemID.ViciousPowder, stack: 10)
                    .AddIngredient(ItemID.GreenSolution, stack: 3)
                    .AddIngredient(ItemID.Bottle, stack: 3)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();

                Recipe purpleSolutionRecipe = Recipe.Create(ItemID.PurpleSolution, amount: 3)
                    .AddIngredient(ItemID.VilePowder, stack: 10)
                    .AddIngredient(ItemID.GreenSolution, stack: 3)
                    .AddIngredient(ItemID.Bottle, stack: 3)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();


                Recipe vilePowderRecipe = Recipe.Create(ItemID.VilePowder, amount: 1)
                    .AddIngredient(ItemID.ViciousPowder, stack: 1)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();

                
                Recipe vicsPowderRecipe = Recipe.Create(ItemID.ViciousPowder, amount: 1)
                    .AddIngredient(ItemID.VilePowder, stack: 1)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
}
