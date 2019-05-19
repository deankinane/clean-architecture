using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.DbAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.Commands.RegisterUser
{
    public class RegisterUserHandler : RequestHandlerBase<RegisterUserCommand>
    {
        public RegisterUserHandler(IDbAccess db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await _db.Users.GeByUsername(request.Username) != null)
            {
                throw new BadRequestException("Username is already registerd");
            }

            var newUser = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username
            };

            newUser.CreatePasswordHash(request.Password);

            await _db.Users.Create(newUser);
            await _db.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
