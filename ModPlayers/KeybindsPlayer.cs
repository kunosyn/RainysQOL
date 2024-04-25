using Microsoft.Xna.Framework;
using RainysQOL.Content.Items.Misc;
using System;
using System.Media;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace RainysQOL.ModPlayers
{
    public class KeybindsPlayer : ModPlayer
    {
        private int warpDebounce = 0;
        private const int WarpDebounceTime = 30;

        private bool IsValidWarpLocation(Vector2 position)
        {
            Vector2 mousePos = default;

            mousePos.X = Main.MouseWorld.X;
            mousePos.Y = Player.gravDir == 1f ? Main.mouseY + Main.screenPosition.Y - Player.height : Main.screenPosition.Y + Main.screenHeight - Main.mouseY;

            ref float x = ref mousePos.X;

            x -= Player.width / 2;

            if (mousePos.X > 50f && mousePos.X < Main.maxTilesX * 16 - 50 && mousePos.Y > 50f && mousePos.Y < Main.maxTilesY * 16 - 50)
            {
                int xInt = (int)(mousePos.X / 16f);
                int yInt = (int)(mousePos.Y / 16f);

                if (Main.tile[xInt, yInt].WallType != 87 && !Collision.SolidCollision(position, Player.width, Player.height))
                {
                    return true;
                }
            }

            return false;
        }

        private void DiscordKey() {
            Vector2 location = Player.gravDir == 1f ? new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y - (Player.height)) : new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y + (Player.height));


            if (Player.HasItemInAnyInventory(ItemID.RodofDiscord) && !Player.HasItemInAnyInventory(ItemID.RodOfHarmony))
            {
                if (Player.HasBuff(BuffID.ChaosState)) return;
                if (!IsValidWarpLocation(location) && RainysQOL.clientConfig.QuickDiscordSafeWarp) return;

                Player.velocity.Y = 0f;
                Player.Teleport(location, 1);

                Player.AddBuff(BuffID.ChaosState, 360);

                warpDebounce = WarpDebounceTime;
            }
            else if (Player.HasItemInAnyInventory(ItemID.RodOfHarmony))
            {
                if (!IsValidWarpLocation(location) && RainysQOL.clientConfig.QuickDiscordSafeWarp) return;

                Player.velocity.Y = 0f;
                Player.Teleport(location, 1);

                warpDebounce = WarpDebounceTime;
            }
        }

        private void PortaNurseKey()
        {
            if (Player.HasBuff<Content.Debuffs.DNR>())
            {
                Main.NewText("[Rainy\'s QOL]: You have a DNR and cannot use medical services!", color: new Color(r: 204, g: 78, b: 69));
                return;
            }


            if (Player.statLife >= Player.statLifeMax2) return;
            long cost = 1000;

            int debuffAmount = 0;
            float healthPercent = Player.statLife / Player.statLifeMax2;

            foreach (int buffType in Player.buffType)
            {
                if (buffType > 0 && buffType < Main.debuff.Length && Main.debuff[buffType])
                {
                    cost += 1000;
                    debuffAmount++;
                }
            }

            cost += (long)(healthPercent * 200000);

            if (Player.BuyItem(price: cost))
            {
                foreach (int buffType in Player.buffType)
                {
                    if (buffType > 0 && buffType < Main.debuff.Length && Main.debuff[buffType])
                    {
                        Player.ClearBuff(buffType);
                    }
                }

                Player.statLife = Player.statLifeMax2;
                Player.statMana = Player.statManaMax2;


                SoundEngine.PlaySound(SoundID.Item4);
                Main.NewText($"[Rainy\'s QOL] Healed {healthPercent * 100}% HP, and cured {debuffAmount} debuff(s) for {ConvertCopperToCurrency(cost)}.");

                Player.AddBuff(ModContent.BuffType<Content.Debuffs.DNR>(), Content.Debuffs.DNR.DurationStandard);
            }
            else
            {
                Main.NewText("[Rainy\'s QOL]: You cannot afford the Porta Nurse!", color: new Color(r: 204, g: 78, b: 69));
            }
        }


        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Player.whoAmI != Main.myPlayer) return;

            if (RainysQOL.PortaNurseKey.JustPressed && Player.HasItemInAnyInventory(ModContent.ItemType<FirstAidKit>()))
            {
                PortaNurseKey();
            }
        }

        public override void PostItemCheck()
        {
            if (Player.whoAmI != Main.myPlayer) return;

            if (RainysQOL.QuickDiscordKey.JustPressed && warpDebounce <= 0)
            {
                DiscordKey();
            }
        }


        public override void PreUpdate()
        {
            if (warpDebounce > 0)
            {
                warpDebounce--;
            }
        }

        public static string ConvertCopperToCurrency(long copperAmount)
        {
            long platinum = copperAmount / 1000000;
            long gold = (copperAmount % 1000000) / 10000;
            long silver = (copperAmount % 10000) / 100;
            long copper = copperAmount % 100;

          
            string currencyString = "";
            if (platinum > 0)
            {
                currencyString += platinum + " platinum ";
            }
            if (gold > 0)
            {
                currencyString += gold + " gold ";
            }
            if (silver > 0)
            {
                currencyString += silver + " silver ";
            }
            if (copper > 0)
            {
                currencyString += copper + " copper";
            }

            return currencyString.Trim();
        }
    }
}