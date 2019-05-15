using CleanArchitecture.Persistence.DbAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.DbAccess
{
    public interface IDbAccess
    {
        ContactDbAccess Contacts { get; }
        ActivityDbAccess Activities { get; }
        UserDbAccess Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
