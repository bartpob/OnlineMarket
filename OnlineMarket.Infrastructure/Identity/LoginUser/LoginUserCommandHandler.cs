using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Users;
using OnlineMarket.Infrastructure.InfrastructureErrors.IdentityErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Identity.LoginUser
{
    public sealed class LoginUserCommandHandler(UserManager<User> _userManager)
        : IRequestHandler<LoginUserCommand, Result<LoginUserResponse>>
    {
        public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            
            if(user == null)
            {
                return Result<LoginUserResponse>.Failure(IdentityErrors.EmailNotExists);
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if(!passwordValid)
            {
                return Result<LoginUserResponse>.Failure(IdentityErrors.WrongPassword);
            }

            var response = new LoginUserResponse(request.Email, request.Email);

            return Result<LoginUserResponse>.Succeeded(response);
        }
    }
}
