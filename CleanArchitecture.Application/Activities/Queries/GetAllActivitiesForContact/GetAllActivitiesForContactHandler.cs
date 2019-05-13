using AutoMapper;
using CleanArchitecture.Application.Activities.DTOs;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Persistence.DbAccess;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Activities.Queries.GetAllActivitiesForContact
{
    public class GetAllActivitiesForContactHandler : RequestHandlerBase<GetAllActivitiesForContactQuery, List<ActivityPreviewDto>>
    {
        public GetAllActivitiesForContactHandler(IDbAccess db) : base(db)
        {
        }

        public override async Task<List<ActivityPreviewDto>> Handle(GetAllActivitiesForContactQuery request, CancellationToken cancellationToken)
        {
            var list = await _db.Activities.GetActivitiesForContact(request.ContactId);

            return Mapper.Map<List<ActivityPreviewDto>>(list);
        }
    }
}
