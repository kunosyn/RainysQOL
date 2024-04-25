using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using MonoMod.Utils;
using System.Threading.Tasks.Dataflow;
using ReLogic.OS.Windows;
using Terraria.Net;
using Terraria.Enums;
using System;
using RainysQOL.Configs;

namespace RainysQOL.Content.Items.Melee
{
    public class Tyrone : ModItem
    {
        public bool canTeamKill = false;
        public override string Texture => RainysQOL.AssetPath + "Textures/Items/Melee/Tyrone";


        public override void SetDefaults()
        {
            Item.damage = 69420;
            Item.DamageType = DamageClass.Melee;
            Item.width = 49;
            Item.height = 128;
            Item.scale = 3f;

            Item.useTime = 30;
            Item.useAnimation = 30;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 2000000;
            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override bool? CanHitNPC(Player player, NPC target)
        {
            if (target.friendly || target.townNPC)
            {
                if (!canTeamKill)
                {
                    return false;
                }

                if (target.type == NPCID.PartyGirl || target.type == NPCID.ArmsDealer || target.type == NPCID.BestiaryGirl || target.type == NPCID.Painter || target.type == NPCID.Guide)
                {
                    return true;
                }
            }
            else if (target.boss || target.BossBar != null)
            {
                player.KillMe(PlayerDeathReason.ByCustomReason($"{player.name} tried cheating the boss and got his booty ripped off"), dmg: 100000000, hitDirection: 1);
                Main.NewText("tyrones meat cannot be wielded against cosmic entities");

                return false;
            }


            return !canTeamKill;
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool CanUseItem(Player player)
        {
            if (!NPC.downedMoonlord)
            {
                Main.NewText("you must acquire tyrone legitimately");

                int index = Array.IndexOf(player.inventory, Item);
                if (index != -1)
                {
                    Main.LocalPlayer.inventory[index].TurnToAir();
                }


                return false;
            }


            if (player.name.ToLower() != "joe biden" && player.name.ToLower() != "rainy")
            {
                player.KillMe(PlayerDeathReason.ByCustomReason($"tyrone penetrated {player.name} before they could wield his meat"), dmg: 100000000, hitDirection: 1);
                return false;
            }

            if (player.altFunctionUse == 2)
            {
                canTeamKill = !canTeamKill;
                Main.NewText(canTeamKill ? "tyrone is ERECT" : "tyrone has erectile disfunction :( consider viagra");

                if (canTeamKill)
                {
                    foreach (Player plr in Main.player)
                    {
                        plr.hostile = true;
                    }
                }
                else
                {
                    foreach (Player plr in Main.player)
                    {
                        plr.hostile = false;
                    }
                }


                return false;
            }

            if (Main.bloodMoon || Main.snowMoon || Main.eclipse || Main.pumpkinMoon)
            {
                Main.NewText("tyrones meat is oddly limp and cannot be used");
                return false;
            }

            return true;
        }


        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            target.KillMe(PlayerDeathReason.ByCustomReason($"{target.name} was penetrated by tyrone at the hands of {player.name}"), dmg: 100000000, hitDirection: 1);
            base.OnHitPvp(player, target, hurtInfo);
        }
    }
}