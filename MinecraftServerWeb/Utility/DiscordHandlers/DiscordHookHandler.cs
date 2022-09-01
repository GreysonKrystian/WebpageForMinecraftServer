using System.Net;
using System.Text;
using Discord;
using Discord.Webhook;
using Microsoft.AspNetCore.Identity;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Utility.Exceptions;


namespace MinecraftServerWeb.Utility.DiscordHandlers
{
    public class DiscordHookHandler : IDiscordHookHandler
    {
        private readonly string _discordIdAndToken;
        private readonly UserManager<IdentityUser> _userManager;
        public DiscordHookHandler(string discordIdAndToken, UserManager<IdentityUser> userManager)
        {
            _discordIdAndToken = discordIdAndToken;
            _userManager = userManager;
        }

        public async Task SendDiscordMessage(Post post)
        {
            using var client = new DiscordWebhookClient("https://discord.com/api/webhooks" + _discordIdAndToken);
            await client.SendMessageAsync(text: post.Content,
                username: post.Author.ServerNickname,
                avatarUrl: post.Author.AvatarUrl);
        }

        public async Task SendDiscordEmbeddedMessage(Announcement announcement)
        {
            using var client = new DiscordWebhookClient("https://discord.com/api/webhooks" + _discordIdAndToken);

            var embed = CreateEmbeddedMessage(announcement);

            await client.SendMessageAsync(embeds: new[] { embed.Build() });
        }

        private EmbedBuilder CreateEmbeddedMessage(Announcement announcement)
        {
            User user = (User)_userManager.FindByIdAsync(announcement.AuthorId).GetAwaiter().GetResult();
            if (user == null)
            {
                throw new UserNotFoundException($"User with id: {announcement.AuthorId} was not found");
            }
            return new EmbedBuilder
            {
                Title = announcement.Title,
                Description = announcement.Content, // TODO Temporary then remove
                Author = new EmbedAuthorBuilder
                {
                    Name = user.ForumNickname,
                    IconUrl = user.AvatarUrl
                },


            };
        }
    }
}
