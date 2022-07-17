using MinecraftServerWeb.Data;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Implementation;
using MinecraftServerWeb.Repository.Interfaces;

namespace MinecraftServerWeb.Repository.RepositoryImplementation
{
    public class UserRepository :Repository<User>, IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(User user)
        {
            _db.Update(user);
        }
    }
}
