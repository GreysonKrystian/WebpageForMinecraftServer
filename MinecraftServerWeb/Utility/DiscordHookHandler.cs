using System.Net;
using System.Text;
using Discord;
using Discord.Webhook;
using MinecraftServerWeb.Models;


namespace MinecraftServerWeb.Utility
{
    public class DiscordHookHandler : IDiscordHookHandler
    {
        private readonly string _discordIdAndToken;
        public DiscordHookHandler(string discordIdAndToken)
        {
            _discordIdAndToken = discordIdAndToken;
        }

        public async Task CreateDiscordMessage(Post post)
        {
            using (var client = new DiscordWebhookClient("https://discord.com/api/webhooks" + _discordIdAndToken))
            {
                var embed = new EmbedBuilder
                {
                    Title = "Test Embed",
                    Description = "Test Description"
                };

                await client.SendMessageAsync(text: "Test!", embeds: new[] { embed.Build() });
            }

        }
    }
}
