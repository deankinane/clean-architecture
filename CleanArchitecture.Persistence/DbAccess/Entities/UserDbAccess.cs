using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.DbAccess.Entities
{
    public class UserDbAccess : EntityDbAccessBase
    {
        public UserDbAccess(DatabaseDbContext context) : base(context)
        {
        }
        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await _context.Users
                .Where(x => x.Username == username)
                .DefaultIfEmpty(null)
                .FirstOrDefaultAsync();

            if(user == null)
            {
                throw new NotFoundException(nameof(User), username);
            }

            return user;
        }
    }
}
