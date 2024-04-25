using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace RainysQOL.ModPlayers
{
    public class BuffsPlayer : ModPlayer
    {
        public bool ConsumableExtraSpeed;
        public override void ResetEffects()
        {
            ConsumableExtraSpeed = false;
        }

        public override bool ModifyNurseHeal(NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText)
        {
            if (Player.HasBuff<Content.Debuffs.DNR>())
            {
                chatText = "You have a DNR order I can\'t help!";
                return false;
            }

            return true;
        }


        public override float UseSpeedMultiplier(Item item)
        {
            return item.consumable && ConsumableExtraSpeed ? 50f : base.UseSpeedMultiplier(item);
        }
    }
}
