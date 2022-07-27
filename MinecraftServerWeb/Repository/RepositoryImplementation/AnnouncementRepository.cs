using MinecraftServerWeb.Data;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.RepositoryInterfaces;
using MinecraftServerWeb.Repository.Implementation;

namespace MinecraftServerWeb.Repository.RepositoryImplementation
{
    public class AnnouncementRepository : Repository<Announcement>, IAnnouncementRepository
    {
        private readonly AppDbContext _db;

        public AnnouncementRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Announcement announcement)
        {
            _db.Update(announcement);
        }
    }
}
