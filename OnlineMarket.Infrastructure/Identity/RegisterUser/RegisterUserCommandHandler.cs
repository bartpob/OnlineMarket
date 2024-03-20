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

namespace OnlineMarket.Infrastructure.Identity.RegisterUser
{
    public class RegisterUserCommandHandler(UserManager<User> _userManager)
        : IRequestHandler<RegisterUserCommand, Result>
    {
        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email 
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    if(error.Code.Contains("Password"))
                    {
                        return Result.Failure(IdentityErrors.InvalidPassword);
                    }

                    if(error.Code.Contains("UserName"))
                    {
                        return Result.Failure(IdentityErrors.EmailAlreadyTaken);
                    }

                    if(error.Code.Contains("Email"))
                    {
                        return Result.Failure(IdentityErrors.InvalidEmail);
                    }
                }

                return Result.Failure(new Error("Unknow", "pozdro"));
            }
            return Result.Succeeded();
        }
    }
}
