using MinecraftServerWeb.Repository.RepositoryInterfaces;

namespace MinecraftServerWeb.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public IPostRepository Post {get;}
        public IUserRepository User {get;}

        public IAnnouncementRepository Announcement {get;}
        void Commit();
    }
}
