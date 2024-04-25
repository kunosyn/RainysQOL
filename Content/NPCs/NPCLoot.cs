using RainysQOL.Configs;
using RainysQOL.Content.Items.Melee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace RainysQOL.Content.NPCs
{
    public class NPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            switch (npc.type)
            {
                case NPCID.PirateCorsair:
                case NPCID.PirateCrossbower:
                case NPCID.PirateDeadeye:
                case NPCID.PirateDeckhand:
                    if (!RainysQOL.serverConfig.CoinSwordEnabled) break;
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CoinSword>(), 4000));
                    break;

                case NPCID.PirateCaptain:
                    if (!RainysQOL.serverConfig.CoinSwordEnabled) break;
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CoinSword>(), 1000));
                    break;

                case NPCID.PirateShip:
                    if (!RainysQOL.serverConfig.CoinSwordEnabled) break;
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CoinSword>(), 50));
                    break;

                case NPCID.MoonLordCore:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Tyrone>(), 10000));
                    break;
            }
        }
    }
}
