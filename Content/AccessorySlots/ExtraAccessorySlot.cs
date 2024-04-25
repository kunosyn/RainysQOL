using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace RainysQOL.Content.AccessorySlots
{
    public class ExtraAccessorySlot : ModAccessorySlot
    {
        private bool Enabled = false;

        private readonly int ID;
        public override string Name => $"ExtraSlot{this.ID}";

        public override bool DrawDyeSlot => true;
        public override bool DrawFunctionalSlot => true;
        public override bool DrawVanitySlot => true;


        public override bool IsVisibleWhenNotEnabled() => false;
        public override bool IsEnabled() => Enabled;


        public ExtraAccessorySlot(int id)
        {
            this.ID = id;
        }

        public void Setup(bool enabled)
        {
            this.Enabled = enabled;
        }
    }
}
