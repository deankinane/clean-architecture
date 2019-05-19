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

        public override Task<User> GetById(int userId)
        {
            return _context.Users.FindAsync(userId);
        }

        public Task<User> GeByUsername(string username)
        {
            return _context.Users
                .Where(x => x.Username == username)
                .DefaultIfEmpty(null)
                .FirstOrDefaultAsync();
        }

        public async override Task Create(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public override Task<List<User>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public override Task Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
