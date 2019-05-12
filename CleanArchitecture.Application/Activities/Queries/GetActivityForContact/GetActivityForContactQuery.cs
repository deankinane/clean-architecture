using CleanArchitecture.Application.Activities.DTOs;
using MediatR;

namespace CleanArchitecture.Application.Activities.Queries.GetAllActivitiesForContact
{
    public class GetActivityForContactQuery : IRequest<ActivityDto>
    {
        public int ContactId { get; set; }
        public int ActivityId { get; set; }
    }
}
