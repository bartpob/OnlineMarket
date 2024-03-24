using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace OnlineMarket.UI.Abstractions
{
    public abstract class BaseHttpService
    {
        protected HttpClient HttpClient { get; set; }

        private ILocalStorageService _localStorageService;
        public BaseHttpService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            HttpClient = httpClient;
            _localStorageService = localStorageService;
        }

        protected async Task AttachBearerToken()
        {
            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            if(token != null)
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
