using Microsoft.EntityFrameworkCore;
using sprawko.Interfaces;
using sprawko.Models;
using System.Linq.Expressions;

namespace sprawko.Services.Repositories
{
    public class HistoryRepository<TEntity> : IHistoryRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public HistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().Where(predicate);

            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

    }
}
