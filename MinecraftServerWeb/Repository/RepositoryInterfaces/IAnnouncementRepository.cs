using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Interfaces;

namespace MinecraftServerWeb.Repository.RepositoryInterfaces;

public interface IAnnouncementRepository : IRepository<Announcement>
{
    void Update(Announcement post);
}