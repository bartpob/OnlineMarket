using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Infrastructure.Identity.LoginUser;
using OnlineMarket.Infrastructure.Identity.RegisterUser;

namespace OnlineMarket.UI.Authentication
{
    public interface IAuthenticationHttpService
    {
        public Task<Result<LoginUserResponse>> PostLoginAsync(LoginUserCommand request);
        public Task<Result> PostRegisterUserAsync(RegisterUserCommand request);
    }
}
