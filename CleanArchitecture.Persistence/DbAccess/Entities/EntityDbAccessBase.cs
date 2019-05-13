
namespace CleanArchitecture.Persistence.DbAccess.Entities
{
    public abstract class EntityDbAccessBase
    {
        protected IDatabaseDbContext _context;

        protected EntityDbAccessBase(IDatabaseDbContext context)
        {
            _context = context;
        }
    }
}
