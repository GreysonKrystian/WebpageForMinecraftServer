using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.Utility.DiscordHandlers
{
    public interface IDiscordHookHandler
    {
        public Task SendDiscordEmbeddedMessage(Announcement announcement);

        public Task SendDiscordMessage(Post post);

    }
}
