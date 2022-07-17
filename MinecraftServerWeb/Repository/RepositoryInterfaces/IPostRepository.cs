using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.Repository.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        void Update(Post post);
    }
}
