using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.DbAccess
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
