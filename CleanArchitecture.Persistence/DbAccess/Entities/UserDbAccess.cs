using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.DbAccess.Entities
{
    public class UserDbAccess : EntityDbAccessBase
    {
        public UserDbAccess(DatabaseDbContext context) : base(context)
        {
        }

        public Task<User> GetUserById(int userId)
        {
            return _context.Users.FindAsync(userId);
        }

        public Task<User> GetUserByUsername(string username)
        {
            return _context.Users
                .Where(x => x.Username == username)
                .DefaultIfEmpty(null)
                .FirstOrDefaultAsync();
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
