using System.Linq.Expressions;

namespace MinecraftServerWeb.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T obj);
        void Remove(T obj);
        void RemoveRange(IEnumerable<T> objects);
        T? GetFirstOrDefault(Expression<Func<T, bool>> filter);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
    }
}
