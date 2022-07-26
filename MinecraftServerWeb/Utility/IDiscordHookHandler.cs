using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.Utility
{
    public interface IDiscordHookHandler
    {
        public Task CreateDiscordMessage(Post post);

    }
}
