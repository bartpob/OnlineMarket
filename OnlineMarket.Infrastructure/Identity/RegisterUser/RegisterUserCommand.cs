using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Identity.RegisterUser
{
    public record RegisterUserCommand(string Email, string Password)
        : IRequest<Result>;
}
