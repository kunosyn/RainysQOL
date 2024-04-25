using Microsoft.CodeAnalysis.CSharp.Syntax;
using RainysQOL.Commands;
using RainysQOL.Configs;
using RainysQOL.Content.AccessorySlots;
using Steamworks;
using System;
using System.IO;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.Social.WeGame;

namespace RainysQOL
{
	public class RainysQOL : Mod
	{
		internal static ModKeybind QuickDiscordKey;
        internal static ModKeybind PortaNurseKey;

        public static ServerConfiguration serverConfig;
        public static ClientConfiguration clientConfig;
        public static ExtraAccessorySlot[] ExtraSlots = new ExtraAccessorySlot[30];
        public static bool Loaded = false;

        public enum PacketMessageType
        {
            MudToDirt
        };


        public const string AssetPath = $"{nameof(RainysQOL)}/Assets/";

        public override void Load()
        {
            QuickDiscordKey = KeybindLoader.RegisterKeybind(this, "QuickDiscord", "Q");
            PortaNurseKey = KeybindLoader.RegisterKeybind(this, "PortaNurse", "Z");

            serverConfig = ModContent.GetInstance<ServerConfiguration>();
            clientConfig = ModContent.GetInstance<ClientConfiguration>();

            for (int i = 0; i < 30; i++)
            {
                ExtraSlots[i] = new ExtraAccessorySlot(i + 1);
                base.AddContent(ExtraSlots[i]);
            }

            Loaded = true;
            serverConfig.OnChanged();
        }


        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            base.HandlePacket(reader, whoAmI);
        }
    }
}