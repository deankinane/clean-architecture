using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Activities.Queries.GetAllActivitiesForContact
{
    public class GetActivityForContactQuery : IRequest<Activity>
    {
        public int ContactId { get; set; }
        public int ActivityId { get; set; }
    }
}
