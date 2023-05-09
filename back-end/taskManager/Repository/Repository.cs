using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using task_manager.Context;

namespace task_manager.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly AppDbContext _context;
        private DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities= context.Set<T>();
        }               

        public IQueryable<T> Get()
        {
            return _entities.AsNoTracking();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _entities.AsNoTracking().SingleOrDefaultAsync(predicate);               
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _entities.Update(entity);
        }


        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }
    }
}
