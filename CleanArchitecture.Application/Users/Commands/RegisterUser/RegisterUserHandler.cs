using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Infrastructure;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.DbAccess;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.Commands.RegisterUser
{
    public class RegisterUserHandler : RequestHandlerBase<RegisterUserCommand>
    {
        private UserManager<User> _userManager;

        public RegisterUserHandler(IDbAccess db, IMapper mapper, UserManager<User> userManager) 
            : base(db, mapper)
        {
            _userManager = userManager;
        }

        public override async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userManager.FindByNameAsync(request.Username) != null)
            {
                throw new BadRequestException("Username is already registerd");
            }

            var newUser = new User()
            {
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);

            if (!result.Succeeded)
            {
                // ToDo fix this
                throw new BadRequestException(result.Errors.ToList()[0].Description);
            }

            return Unit.Value;
        }
    }
}
