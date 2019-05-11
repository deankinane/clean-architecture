using CleanArchitecture.Application.Exceptions;
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
    public class GetActivityForContactHandler : RequestHandlerBase, IRequestHandler<GetActivityForContactQuery, Activity>
    {
        public GetActivityForContactHandler(DatabaseDbContext context) : base(context) { }

        public async Task<Activity> Handle(GetActivityForContactQuery request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities
                .FindAsync(request.ActivityId);

            if(activity == null)
            {
                throw new NotFoundException(nameof(Activity), request.ActivityId);
            }

            if (activity.ContactId != request.ContactId)
            {
                throw new BadRequestException(nameof(Contact), request.ContactId, nameof(Activity), request.ActivityId);
            }

            return activity;
        }
    }
}
