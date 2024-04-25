using System;
using System.Net.Http;
using System.Threading.Tasks;
using Terraria;
using Steamworks;
using Terraria.ModLoader;
using RainysQOL.Configs;
using Terraria.ID;

namespace RainysQOL.Commands
{
    public class AnnounceCommand : ModCommand
    {
        public override string Command => "announce";
        public override CommandType Type => CommandType.Chat;

        private string steamName, steamLink;
        private CSteamID steamID;
        private ServerConfiguration modConfig;

        public override void SetStaticDefaults()
        {
            // Initial Values
            steamName = "Error";
            steamLink = "https://steamcommunity.com/";
            
            // Actual Values
            steamID = SteamUser.GetSteamID();
            steamName = SteamFriends.GetFriendPersonaName(steamID);
            steamLink = $"https://steamcommunity.com/profiles/{steamID.m_SteamID}";


            modConfig = ModContent.GetInstance<ServerConfiguration>();
        }

        public override async void Action(CommandCaller caller, string input, string[] args)
        {
            if (!modConfig.WebhookEnabled)
            {
                Main.NewText("[Rainy's QOL]: Webhooks announcer must be enabled in mod config.");
                return;
            }

            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText("[Rainy's QOL]: You must be in an online multiplayer session to use webhook functionality.");
                return;
            }
           
            if (args.Length <= 0)
            {
                Main.NewText("[Rainy's QOL]: No password was provided.");
                return;
            }


   
            string password = string.Join(" ", args);

            await Task.Yield();
            await SendWebhook(password);
        }

        public async Task SendWebhook(string password)
        {
            try
            {
                using (HttpClient client = new HttpClient()) {
                    string mention = modConfig.MentionEveryone ? "@everyone" : "@here";
                    string hexValue = modConfig.WebhookColor;

                    hexValue = hexValue.Replace("#", "");
                    int decimalValue = Convert.ToInt32(hexValue, 16);


                    string json = $@"
                        {{
                            ""content"": ""{mention}"",
                            ""embeds"": [
                                {{
                                    ""author"": {{
                                        ""name"": ""{steamName} ({steamID.GetAccountID()})"",
                                        ""url"": ""{steamLink}"",
                                        ""icon_url"": ""{modConfig.WebhookAuthorImageURL}""
                                    }},

                                    ""title"": ""Server Started"",
                                    ""description"": ""{modConfig.WebhookMessage}"",
                                    ""color"": {decimalValue},

                                    ""fields"": [
                                        {{ ""name"": ""**Password**"", ""value"": ""{password}"" }}
                                    ],

                                    ""thumbnail"": {{ ""url"": ""{modConfig.WebhookThumbnailURL}"" }}
                                }}
                            ]
                        }}
                    ";

                    HttpContent content = new StringContent(json);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    HttpResponseMessage response = await client.PostAsync(modConfig.WebhookLink, content);


                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Successfully sent notifier.");
                        Main.NewText("[Rainy's QOL]: Sent notification!");
                    } 
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                        Main.NewText("[Rainy's QOL]: Notification could not send.");
                    }
                }

            } 
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
