using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.DbAccess.Entities
{
    public class EntityDbAccessBase<TEntity> where TEntity : class
    {
        protected DatabaseDbContext _context;

        protected EntityDbAccessBase(DatabaseDbContext context)
        {
            _context = context;
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            return _context.Set<TEntity>().ToListAsync();
        }
        
        public virtual Task<TEntity> GetById(int id)
        {
            return _context.Set<TEntity>().FindAsync(id);
        }

        public virtual Task Create(TEntity entity)
        {
            return _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            
            _context.Set<TEntity>().Update(entity);
        }

        public virtual async Task Delete(int id)
        {
            var entityToDelete = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(entityToDelete);
            return;
        }
    }
}
