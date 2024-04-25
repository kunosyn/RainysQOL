using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace RainysQOL.Content.Dusts
{
    public class BrightGreenSolution : ModDust
    {
        public override string Texture => RainysQOL.AssetPath + "Textures/Dusts/BrightGreenSolution";

        public override void SetStaticDefaults()
        {
            UpdateType = 110;
        }
    }
}
