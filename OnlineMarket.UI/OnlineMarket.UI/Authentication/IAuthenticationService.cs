using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Infrastructure.Identity.LoginUser;

namespace OnlineMarket.UI.Authentication
{
    public interface IAuthenticationService
    {
        public Task<Result> AuthenticateAsync(LoginUserCommand request);
        public Task Logout();
    }
}
