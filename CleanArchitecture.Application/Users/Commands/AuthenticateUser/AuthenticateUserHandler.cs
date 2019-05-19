using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Application.Users.DTOs;
using CleanArchitecture.Persistence.DbAccess;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.Commands.AuthenticateUser
{
    public class AuthenticateUserHandler : RequestHandlerBase<AuthenticateUserCommand, UserDto>
    {
        public AuthenticateUserHandler(IDbAccess db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<UserDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.GeByUsername(request.Username);

            if (user == null || !user.VerifyPasswordHash(request.Password))
            {
                throw new BadRequestException("Username or password is not correct.");
            }

            return _mapper.Map<UserDto>(user);
        }
    }



}
