using CleanArchitecture.Application.Activities.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Activities.Queries.GetAllActivitiesForContact
{
    public class GetAllActivitiesForContactQuery : IRequest<List<ActivityPreviewDto>>
    {
        public int ContactId { get; set; }
    }
}
