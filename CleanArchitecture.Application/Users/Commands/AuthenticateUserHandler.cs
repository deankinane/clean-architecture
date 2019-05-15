using AutoMapper;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Application.Users.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.DbAccess;
using CleanArchitecture.Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.Commands
{
    public class AuthenticateUserHandler : RequestHandlerBase<AuthenticateUserCommand, UserDto>
    {
        public AuthenticateUserHandler(IDbAccess db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<UserDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.GetUserByUsername(request.Username);

            if (!User.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }
    }



}
