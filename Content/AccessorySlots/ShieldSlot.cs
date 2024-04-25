using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RainysQOL.Content.AccessorySlots
{
    public class ShieldSlot : ModAccessorySlot
    {
        public override bool IsVisibleWhenNotEnabled() => false;
        public override bool IsEnabled() => RainysQOL.serverConfig.ShieldSlotEnabled;
        public override string FunctionalTexture => RainysQOL.AssetPath + "UI/ShieldSlotIcon";

        public override string VanityBackgroundTexture => "Terraria/Images/Inventory_Back8";
        public override string DyeBackgroundTexture => "Terraria/Images/Inventory_Back12";

        public List<int> ManualExceptions = new List<int> { };


        public override void Load()
        {
            // Placeholder for when manual exceptions are added
        }

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {

            if ((context == AccessorySlotType.FunctionalSlot || context == AccessorySlotType.VanitySlot) && (base.CanAcceptItem(checkItem, context) || ManualExceptions.Contains(checkItem.type)))
            {
                return ManualExceptions.Contains(checkItem.type) || checkItem.shieldSlot != -1;
            }

            return false;
        }

        public override void OnMouseHover(AccessorySlotType context)
        {
            if (context == AccessorySlotType.FunctionalSlot)
            {
                Main.hoverItemName = "Shield";
            } 
            else if (context == AccessorySlotType.VanitySlot)
            {
                Main.hoverItemName = "Social Shield";
            }
            else if (context == AccessorySlotType.DyeSlot)
            {
                Main.hoverItemName = "Shield Dye";
            }
        }
    }
}
