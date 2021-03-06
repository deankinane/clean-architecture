﻿using AutoMapper;
using CleanArchitecture.Application.Activities.DTOs;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.DbAccess;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Activities.Queries.GetAllActivitiesForContact
{
    public class GetAllActivitiesForContactHandler : RequestHandlerBase<GetAllActivitiesForContactQuery, List<ActivityPreviewDto>>
    {
        public GetAllActivitiesForContactHandler(IDbAccess db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<List<ActivityPreviewDto>> Handle(GetAllActivitiesForContactQuery request, CancellationToken cancellationToken)
        {
            var list = await _db.Activities.GetActivitiesForContact(request.ContactId);

            if (list == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContactId);
            }

            return _mapper.Map<List<ActivityPreviewDto>>(list);
        }
    }
}
