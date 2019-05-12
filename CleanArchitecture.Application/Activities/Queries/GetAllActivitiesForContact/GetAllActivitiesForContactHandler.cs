using AutoMapper;
using CleanArchitecture.Application.Activities.DTOs;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Activities.Queries.GetAllActivitiesForContact
{
    public class GetAllActivitiesForContactHandler : RequestHandlerBase<GetAllActivitiesForContactQuery, List<ActivityPreviewDto>>
    {
        public GetAllActivitiesForContactHandler(DatabaseDbContext context) : base(context) { }

        public override async Task<List<ActivityPreviewDto>> Handle(GetAllActivitiesForContactQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Activities
                .AsNoTracking()
                .Include(x => x.ActivityType)
                .Include(x => x.Contact)
                .Where(x => x.ContactId == request.ContactId)
                .ToListAsync(cancellationToken);

            return Mapper.Map<List<ActivityPreviewDto>>(list);
        }
    }
}
