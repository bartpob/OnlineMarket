using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnlineMarket.UI.Authentication
{
    public class ApiAuthenticationStateProvider(ILocalStorageService _localStorage, JwtSecurityTokenHandler _jwtTokenHandler)
        : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            var token = await _localStorage.GetItemAsync<string>("accessToken");
            
            if(token == null)
            {
                return new AuthenticationState(user);
            }

            var tokenContent = _jwtTokenHandler.ReadJwtToken(token);

            if(tokenContent.ValidTo < DateTime.UtcNow)
            {
                await _localStorage.RemoveItemAsync("accessToken");
                return new AuthenticationState(user);
            }

            var claims = await GetClaims();

            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

            return new AuthenticationState(user);
        }
        public async Task LoggedIn()
        {
            var claims = await GetClaims();
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));

            NotifyAuthenticationStateChanged(authState);
        }

        public async Task LoggedOut()
        {
            await _localStorage.RemoveItemAsync("accessToken");
            var nobody = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(nobody));

            NotifyAuthenticationStateChanged(authState);
        }


        private async Task<List<Claim>> GetClaims()
        {
            var token = await _localStorage.GetItemAsync<string>("accessToken");
            var tokenContent = _jwtTokenHandler.ReadJwtToken(token);

            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));

            return claims;
        }
    }
}
