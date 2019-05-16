using CleanArchitecture.Persistence.DbAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.DbAccess
{
    public class DbAccess : IDbAccess
    {
        private DatabaseDbContext _context;

        public ContactDbAccess Contacts { get; }
        public ActivityDbAccess Activities { get; }
        public UserDbAccess Users { get; }

        public DbAccess(DatabaseDbContext context)
        {
            _context = context;
            Contacts = new ContactDbAccess(context);
            Activities = new ActivityDbAccess(context);
            Users = new UserDbAccess(context);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
