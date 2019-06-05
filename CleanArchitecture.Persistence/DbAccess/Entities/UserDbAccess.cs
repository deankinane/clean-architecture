using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.DbAccess.Entities
{
    public class UserDbAccess : EntityDbAccessBase<User>
    {
        public UserDbAccess(DatabaseDbContext context) : base(context)
        {
        }

        public Task<User> GeByUsername(string username)
        {
            return _context.Users
                .Where(x => x.Username == username)
                .DefaultIfEmpty(null)
                .FirstOrDefaultAsync();
        }
    }
}
