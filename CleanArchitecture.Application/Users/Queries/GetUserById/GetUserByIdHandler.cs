using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Application.Users.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.DbAccess;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : RequestHandlerBase<GetUserByIdQuery, UserDto>
    {
        public GetUserByIdHandler(IDbAccess db, IMapper mapper) : base(db, mapper)
        {
        }

        public override async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.GetUserById(request.UserId);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}
