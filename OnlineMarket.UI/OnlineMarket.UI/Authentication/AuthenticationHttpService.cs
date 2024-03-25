using Blazored.LocalStorage;
using Newtonsoft.Json;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Infrastructure.Identity.LoginUser;
using OnlineMarket.Infrastructure.Identity.RegisterUser;
using OnlineMarket.UI.Abstractions;
using System.Net.Http.Json;

namespace OnlineMarket.UI.Authentication
{
    public class AuthenticationHttpService
        : BaseHttpService, IAuthenticationHttpService
    {
        public AuthenticationHttpService(HttpClient client, ILocalStorageService storageService)
            : base(client, storageService) { }
        public async Task<Result<LoginUserResponse>> PostLoginAsync(LoginUserCommand request)
        {
            var result = await HttpClient.PostAsJsonAsync<LoginUserCommand>("Auth/Login", request);

            if (result != null)
            {
                string responseBody = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode) 
                {
                    LoginUserResponse response = JsonConvert.DeserializeObject<LoginUserResponse>(responseBody)!;

                    return Result<LoginUserResponse>.Succeeded(response);
                }
                else
                {
                    Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;

                    return Result<LoginUserResponse>.Failure(error);
                }
            }

            else
            {
                return Result<LoginUserResponse>.Failure(new Error("FATAL_ERROR", null));
            }
        }

        public async Task<Result> PostRegisterUserAsync(RegisterUserCommand request)
        {
            var result = await HttpClient.PostAsJsonAsync<RegisterUserCommand>("Auth/Register", request);

            if (result != null)
            {
                string responseBody = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    LoginUserResponse response = JsonConvert.DeserializeObject<LoginUserResponse>(responseBody)!;

                    return Result.Succeeded();
                }
                else
                {
                    Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;

                    return Result.Failure(error);
                }
            }

            else
            {
                return Result.Failure(new Error("FATAL_ERROR", null));
            }
        }
    }
}
