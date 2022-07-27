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

        public async Task SendDiscordMessage(Post post)
        {
            using var client = new DiscordWebhookClient("https://discord.com/api/webhooks" + _discordIdAndToken);
            await client.SendMessageAsync(text: post.Content, 
                username: post.Author.PublicNickname,
                avatarUrl: post.Author.AvatarUrl);
        }

        public async Task SendDiscordEmbeddedMessage(Announcement announcement)
        {
            using var client = new DiscordWebhookClient("https://discord.com/api/webhooks" + _discordIdAndToken);

            var embed = CreateEmbeddedMessage(announcement);

            await client.SendMessageAsync(text: announcement.Content, embeds: new[] { embed.Build() });
        }

        private EmbedBuilder CreateEmbeddedMessage(Announcement announcement)
        {
            return new EmbedBuilder
            {
                Title = announcement.Title,
                Description = announcement.Description,
                Author = new EmbedAuthorBuilder
                {
                    Name = announcement.Author.PublicNickname,
                    IconUrl = announcement.Author.AvatarUrl
                },


            };
        }
    }
}
