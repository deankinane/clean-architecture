using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityHandler : IRequestHandler<CreateActivityCommand, int>
    {
        private DatabaseDbContext _context;

        public CreateActivityHandler(DatabaseDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var newActivity = await _context.Activities.AddAsync(Mapper.Map<Activity>(request), cancellationToken);
            await _context.SaveChangesAsync();
            return newActivity.Entity.ActivityId;
        }
    }
}
