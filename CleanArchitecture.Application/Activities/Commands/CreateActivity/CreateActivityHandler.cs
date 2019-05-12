using AutoMapper;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityHandler : RequestHandlerBase<CreateActivityCommand, int>
    {
        public CreateActivityHandler(IDatabaseDbContext context) : base(context)
        {
        }

        public override async Task<int> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var newActivity = await _context.Activities.AddAsync(Mapper.Map<Activity>(request), cancellationToken);
            await _context.SaveChangesAsync();
            return newActivity.Entity.ActivityId;
        }
    }
}
