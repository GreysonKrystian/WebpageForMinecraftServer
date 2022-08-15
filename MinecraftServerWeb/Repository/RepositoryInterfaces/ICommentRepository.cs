using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Interfaces;

namespace MinecraftServerWeb.Repository.RepositoryInterfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        void Update(Comment comment);
        void ChangeRating(Comment comment, int changeValue);
    }
}
