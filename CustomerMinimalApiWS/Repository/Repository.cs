using CustomerMinimalApiWS.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerMinimalApiWS.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly CustomerDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(CustomerDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            var result = dbSet.Where(filter);
            return result.FirstOrDefault();
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
