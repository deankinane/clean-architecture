using AutoMapper;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence;
using CleanArchitecture.Persistence.DbAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityHandler : RequestHandlerBase<CreateActivityCommand, int>
    {
        public CreateActivityHandler(IDbAccess db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<int> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = _mapper.Map<Activity>(request);
            await _db.Activities.CreateActivty(activity);
            await _db.SaveChangesAsync();

            return activity.ActivityId;
        }
    }
}
