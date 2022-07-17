using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
    }
}
