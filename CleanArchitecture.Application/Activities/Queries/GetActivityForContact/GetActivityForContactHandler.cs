﻿using AutoMapper;
using CleanArchitecture.Application.Activities.DTOs;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.DbAccess;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Activities.Queries.GetAllActivitiesForContact
{
    public class GetActivityForContactHandler : RequestHandlerBase<GetActivityForContactQuery, ActivityDto>
    {
        public GetActivityForContactHandler(IDbAccess db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<ActivityDto> Handle(GetActivityForContactQuery request, CancellationToken cancellationToken)
        {
            var activity = await _db.Activities.GetById(request.ActivityId);

            if (activity == null)
            {
                throw new NotFoundException(nameof(Activity), request.ActivityId);
            }

            if (activity.ContactId != request.ContactId)
            {
                throw new BadRequestException(nameof(Contact), request.ContactId, nameof(Activity), request.ActivityId);
            }

            return _mapper.Map<ActivityDto>(activity);
        }
    }
}
