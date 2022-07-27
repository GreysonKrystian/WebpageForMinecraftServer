using MinecraftServerWeb.Data;
using MinecraftServerWeb.Repository.Interfaces;
using MinecraftServerWeb.Repository.RepositoryInterfaces;

namespace MinecraftServerWeb.Repository.RepositoryImplementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Post = new PostRepository(_db);
            User = new UserRepository(_db);
            Announcement = new AnnouncementRepository(_db);
        }
        public IPostRepository Post {get;}
        public IUserRepository User {get;}
        public IAnnouncementRepository Announcement {get;}


        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
