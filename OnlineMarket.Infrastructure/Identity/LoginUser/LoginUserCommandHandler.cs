using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Users;
using OnlineMarket.Infrastructure.Authentication;
using OnlineMarket.Infrastructure.InfrastructureErrors.IdentityErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Identity.LoginUser
{
    public sealed class LoginUserCommandHandler(UserManager<User> _userManager, Authentication.IAuthenticationService _authService)
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

            var token = await _authService.GenerateTokenAsync(user);

            var response = new LoginUserResponse(request.Email, token);

            return Result<LoginUserResponse>.Succeeded(response);
        }
    }
}
