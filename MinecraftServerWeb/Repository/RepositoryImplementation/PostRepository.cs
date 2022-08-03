using MinecraftServerWeb.Data;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Implementation;
using MinecraftServerWeb.Repository.Interfaces;

namespace MinecraftServerWeb.Repository.RepositoryImplementation
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly AppDbContext _db;

        public PostRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Post post)
        {
            _db.Update(post);
        }
    }
}
