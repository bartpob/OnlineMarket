using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Identity.LoginUser
{
    public sealed record LoginUserCommand(string Email, string Password)
        : IRequest<Result<LoginUserResponse>>;

    public sealed record LoginUserResponse(string Email, string AuthToken);
}
