using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Activities.Queries.GetAllActivitiesForContact
{
    public class GetAllActivitiesForContactQuery : IRequest<List<Activity>>
    {
        public int ContactId { get; set; }
    }
}
