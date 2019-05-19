using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.DbAccess.Entities
{
    public abstract class EntityDbAccessBase<T>
    {
        protected DatabaseDbContext _context;

        protected EntityDbAccessBase(DatabaseDbContext context)
        {
            _context = context;
        }

        public abstract Task<List<T>> GetAll();
        public abstract Task<T> GetById(int id);
        public abstract Task Create(T entity);
        public abstract Task Update(T entity);
        public abstract Task Delete(int id);
    }
}
