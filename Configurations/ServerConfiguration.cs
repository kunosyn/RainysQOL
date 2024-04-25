using RainysQOL.Content.AccessorySlots;
using System;
using System.ComponentModel;
using Terraria;
using Terraria.ModLoader.Config;

namespace RainysQOL.Configs
{
    [BackgroundColor(99, 69, 122)]
    public class ServerConfiguration : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        

        public override void OnChanged()
        {
            if (!RainysQOL.Loaded) return;

            for (int i = 0; i < 30; i++)
            {
                RainysQOL.ExtraSlots[i].Setup(i < ExtraAccessorySlots);
            }
        }

        #region discord

        [Header("Discord")]

        [DefaultValue(false)]
        [BackgroundColor(191, 140, 230)]
        public bool WebhookEnabled;


        [DefaultValue("")]
        [BackgroundColor(191, 140, 230)]
        public string WebhookLink;


        [DefaultValue("")]
        [BackgroundColor(191, 140, 230)]
        public string WebhookMessage;

        [DefaultValue(false)]
        [BackgroundColor(191, 140, 230)]
        public bool MentionEveryone;


        [DefaultValue("https://cdnb.artstation.com/p/assets/images/images/018/572/453/large/ivan-lam-calamity-logo.jpg?1559861444")]
        [BackgroundColor(191, 140, 230)]
        public string WebhookThumbnailURL;

        [DefaultValue("https://static.wikia.nocookie.net/total-calamity-wiki/images/3/35/KingSlimeCT3.gif/revision/latest/thumbnail/width/360/height/360?cb=20220909233936")]
        [BackgroundColor(191, 140, 230)]
        public string WebhookAuthorImageURL;


        [DefaultValue("#852d3a")]
        [BackgroundColor(191, 140, 230)]
        public string WebhookColor;

        #endregion

        #region accessoryconfig

        [Header("AccessoryConfig")]



        [DefaultValue(true)]
        [BackgroundColor(191, 140, 230)]
        public bool ShieldSlotEnabled;

        [DefaultValue(true)]
        [BackgroundColor(191, 140, 230)]
        public bool WingSlotEnabled;

        [DefaultValue(true)]
        [BackgroundColor(191, 140, 230)]
        public bool ShoeSlotEnabled;

        [DefaultValue(0)]
        [Range(0, 30)]
        [BackgroundColor(191, 140, 230)]
        public int ExtraAccessorySlots;

        #endregion

        #region recipes

        [Header("Recipes")]

        [DefaultValue(true)]
        [ReloadRequired]
        [BackgroundColor(191, 140, 230)]
        public bool ClentaminatorRecipe;

        [DefaultValue(true)]
        [ReloadRequired]
        [BackgroundColor(191, 140, 230)]
        public bool WarTableRecipe;

        [DefaultValue(true)]
        [ReloadRequired]
        [BackgroundColor(191, 140, 230)]
        public bool GreenSolutionRecipe;

        [DefaultValue(true)]
        [ReloadRequired]
        [BackgroundColor(191, 140, 230)]
        public bool DarkBlueSolutionRecipe;

        [DefaultValue(true)]
        [ReloadRequired]
        [BackgroundColor(191, 140, 230)]
        public bool BlueSolutionRecipe;

        [DefaultValue(true)]
        [ReloadRequired]
        [BackgroundColor(191, 140, 230)]
        public bool WhiteSolutionRecipe;

        [DefaultValue(true)]
        [ReloadRequired]
        [BackgroundColor(191, 140, 230)]
        public bool EvilSolutionsRecipes;

        [DefaultValue(true)]
        [ReloadRequired]
        [BackgroundColor(191, 140, 230)]
        public bool YellowSolutionRecipe;

        #endregion

        #region modpatches
        [Header("CrossModPatches")]

        [DefaultValue(false)]
        [BackgroundColor(191, 140, 230)]
        public bool PatchFargosCraftingReworks;

        [DefaultValue(false)]
        [BackgroundColor(191, 140, 230)]
        public bool ReworkFargosCrafting;

        #endregion



        #region customitems

        [Header("CustomItems")]

        [DefaultValue(true)]
        [ReloadRequired]
        [BackgroundColor(191, 140, 230)]
        public bool CoinSwordEnabled;


        [DefaultValue(true)]
        [ReloadRequired]
        [BackgroundColor(191, 140, 230)]
        public bool ToolGunEnabled;

        [DefaultValue(true)]
        [ReloadRequired]
        [BackgroundColor(191, 140, 230)]
        public bool SummonersControllerEnabled;

        #endregion
    }
}
