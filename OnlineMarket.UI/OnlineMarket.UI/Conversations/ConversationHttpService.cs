using Blazored.LocalStorage;
using Newtonsoft.Json;
using OnlineMarket.Application.Announcements.EditAnnoucement;
using OnlineMarket.Application.Announcements.GetAllAnnouncements;
using OnlineMarket.Application.Conversations.GetConversation;
using OnlineMarket.Application.Conversations.SendMessage;
using OnlineMarket.Application.Conversations.StartNewConversation;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.UI.Abstractions;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace OnlineMarket.UI.Conversations
{
    public class ConversationHttpService
        : BaseHttpService, IConversationHttpService
    {
        public ConversationHttpService(HttpClient httpClient, ILocalStorageService localStorageService) 
            : base(httpClient, localStorageService)
        {}

        public async Task<Result<ConversationResponse>> GetConversation(Guid Id)
        {
            await AttachBearerToken();

            var result = await HttpClient.GetAsync($"Conversation/{Id}");

            string responseBody = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                ConversationResponse response = JsonConvert.DeserializeObject<ConversationResponse>(responseBody)!;
                return Result<ConversationResponse>.Succeeded(response);
            }
            else
            {
                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result<ConversationResponse>.Failure(error);
            }
        }

        public async Task<Result<IEnumerable<ConversationResponse>>> GetConversations()
        {
            await AttachBearerToken();

            var result = await HttpClient.GetAsync("Conversation/");

            string responseBody = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                IEnumerable <ConversationResponse> response = JsonConvert.DeserializeObject<IEnumerable<ConversationResponse>>(responseBody)!;
                return Result<IEnumerable<ConversationResponse>>.Succeeded(response);
            }
            else
            {
                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result<IEnumerable<ConversationResponse>>.Failure(error);
            }
        }

        public async Task<Result> SendMessage(Guid Id, SendMessageRequest request)
        {
            await AttachBearerToken();

            var result = await HttpClient.PostAsJsonAsync<SendMessageRequest>($"Conversation/SendMessage/{Id}", request);

            if (result.IsSuccessStatusCode)
            {
                return Result.Succeeded();
            }
            else
            {
                string responseBody = await result.Content.ReadAsStringAsync();

                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result.Failure(error);
            }
        }

        public async Task<Result> StartConversation(StartNewConversationRequest request)
        {
            await AttachBearerToken();

            var result = await HttpClient.PostAsJsonAsync<StartNewConversationRequest>($"Conversation/StartConversation", request);

            if (result.IsSuccessStatusCode)
            {
                return Result.Succeeded();
            }
            else
            {
                string responseBody = await result.Content.ReadAsStringAsync();

                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result.Failure(error);
            }
        }
    }
}
