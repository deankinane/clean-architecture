using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Application.Users.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.DbAccess;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : RequestHandlerBase<GetUserByIdQuery, UserDto>
    {
        private UserManager<User> _userManager;

        public GetUserByIdHandler(IDbAccess db, IMapper mapper, UserManager<User> userManager) 
            : base(db, mapper)
        {
            _userManager = userManager;
        }

        public override async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}
