using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace RainysQOL.Content.AccessorySlots
{
    public class ShoeSlot : ModAccessorySlot
    {
        public override bool IsVisibleWhenNotEnabled() => false;
        public override bool IsEnabled() => RainysQOL.serverConfig.ShoeSlotEnabled;
        public override string FunctionalTexture => RainysQOL.AssetPath + "UI/ShoeSlotIcon";

        public override string VanityBackgroundTexture => "Terraria/Images/Inventory_Back8";
        public override string DyeBackgroundTexture => "Terraria/Images/Inventory_Back12";

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {

            if ((context == AccessorySlotType.FunctionalSlot || context == AccessorySlotType.VanitySlot) && base.CanAcceptItem(checkItem, context))
            {
                return checkItem.shoeSlot != -1;
            }

            return false;
        }

        public override void OnMouseHover(AccessorySlotType context)
        {
            if (context == AccessorySlotType.FunctionalSlot)
            {
                Main.hoverItemName = "Shoes";
            }
            else if (context == AccessorySlotType.VanitySlot)
            {
                Main.hoverItemName = "Social Shoes";
            }
            else if (context == AccessorySlotType.DyeSlot)
            {
                Main.hoverItemName = "Shoes Dye";
            }
        }
    }
}
