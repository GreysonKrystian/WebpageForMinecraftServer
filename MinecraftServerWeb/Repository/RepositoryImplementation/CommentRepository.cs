using MinecraftServerWeb.Data;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Implementation;
using MinecraftServerWeb.Repository.RepositoryInterfaces;

namespace MinecraftServerWeb.Repository.RepositoryImplementation
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly AppDbContext _db;

        public CommentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Comment comment)
        {
            _db.Update(comment);
        }

        public void ChangeRating(Comment comment, int changeValue)
        {
            comment.Rating += changeValue;
            _db.Update(comment);
        }
    }
}
