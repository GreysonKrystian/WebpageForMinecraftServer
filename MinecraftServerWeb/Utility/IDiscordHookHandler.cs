using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.Utility
{
    public interface IDiscordHookHandler
    {
        public Task SendDiscordEmbeddedMessage(Announcement announcement);

        public Task SendDiscordMessage(Post post);

    }
}
