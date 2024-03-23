using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Infrastructure.Authentication;
using OnlineMarket.Infrastructure.Identity.LoginUser;
using OnlineMarket.Infrastructure.Identity.RegisterUser;
using OnlineMarket.UI.Abstractions;
using System.Net;
using System.Text.Json;

namespace OnlineMarket.UI.Authentication
{
    public class AuthenticationService(IAuthenticationHttpService _httpService, AuthenticationStateProvider _authenticationProvider,
        ILocalStorageService _localStorage)
        : IAuthenticationService
    {
        public async Task<Result> AuthenticateAsync(LoginUserCommand request)
        {
            var result = await _httpService.PostLoginAsync(request);

            if(result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            await _localStorage.SetItemAsync("accessToken", result.Body!.AuthToken);

            await ((ApiAuthenticationStateProvider)_authenticationProvider).LoggedIn();

            return Result.Succeeded();
        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)_authenticationProvider).LoggedOut();
        }
    }
}
