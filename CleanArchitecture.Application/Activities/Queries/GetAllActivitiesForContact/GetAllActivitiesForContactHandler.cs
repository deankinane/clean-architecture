using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Activities.Queries.GetAllActivitiesForContact
{
    public class GetAllActivitiesForContactHandler : RequestHandlerBase, IRequestHandler<GetAllActivitiesForContactQuery, List<Activity>>
    {
        public GetAllActivitiesForContactHandler(DatabaseDbContext context) : base(context) { }

        public Task<List<Activity>> Handle(GetAllActivitiesForContactQuery request, CancellationToken cancellationToken)
        {
            return _context.Activities
                .AsNoTracking()
                .Where(x => x.ContactId == request.ContactId)
                .ToListAsync(cancellationToken);
        }
    }
}
