namespace CleanArchitecture.Persistence.DbAccess.Entities
{
    public abstract class EntityDbAccessBase
    {
        protected DatabaseDbContext _context;

        protected EntityDbAccessBase(DatabaseDbContext context)
        {
            _context = context;
        }
    }
}
