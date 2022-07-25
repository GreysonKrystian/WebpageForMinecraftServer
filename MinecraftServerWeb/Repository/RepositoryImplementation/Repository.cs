using Microsoft.EntityFrameworkCore;
using MinecraftServerWeb.Data;
using MinecraftServerWeb.Repository.Interfaces;
using System.Linq.Expressions;

namespace MinecraftServerWeb.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T obj)
        {
            _db.Add(obj);
            
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            return query.Where(filter);
        }

        public void Remove(T obj)
        {
            dbSet.Remove(obj);
        }

        public void RemoveRange(IEnumerable<T> objects)
        {
            dbSet.RemoveRange(objects);
        }
    }
}
