using Azure.Core;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using OnlineMarket.Application.Announcements.AddAnnoucement;
using OnlineMarket.Application.Announcements.EditAnnoucement;
using OnlineMarket.Application.Announcements.GetAllAnnouncements;
using OnlineMarket.Application.Announcements.RejectAnnoucement;
using OnlineMarket.Application.Categories.GetAllCategories;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.UI.Abstractions;

namespace OnlineMarket.UI.Announcements
{
    public class AnnouncementHttpService
        : BaseHttpService, IAnnouncementHttpService
    {
        public AnnouncementHttpService(HttpClient httpClient, ILocalStorageService localStorageService) 
            : base(httpClient, localStorageService) {}

        public async Task<Result> AcceptAnnouncement(Guid Id)
        {
            await AttachBearerToken();

            var result = await HttpClient.PostAsync($"Announcement/Moderator/Verify/Accept/{Id}", null);

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

        public async Task<Result> AddAnnouncement(AddAnnouncementRequest request)
        {
            await AttachBearerToken();

            var result = await HttpClient.PostAsJsonAsync<AddAnnouncementRequest>($"Announcement/", request);

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

        public async Task<Result> DeleteAnnouncement(Guid Id)
        {
            await AttachBearerToken();

            var result = await HttpClient.DeleteAsync($"Announcement/{Id}");

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

        public async Task<Result> EditAnnouncement(Guid Id, EditAnnouncementRequest request)
        {
            await AttachBearerToken();

            var result = await HttpClient.PutAsJsonAsync<EditAnnouncementRequest>($"Announcement/{Id}", request);

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

        public async Task<Result<AnnouncementResponse>> GetAnnouncement(Guid Id)
        {
            var result = await HttpClient.GetAsync($"Announcement/{Id}");

            string responseBody = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                AnnouncementResponse response = JsonConvert.DeserializeObject<AnnouncementResponse>(responseBody)!;
                return Result<AnnouncementResponse>.Succeeded(response);
            }
            else
            {
                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result<AnnouncementResponse>.Failure(error);
            }
        }

        public async Task<Result<IEnumerable<AnnouncementResponse>>> GetAnnouncements()
        {
            var result = await HttpClient.GetAsync("Announcement/");

            string responseBody = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                IEnumerable<AnnouncementResponse> response = JsonConvert.DeserializeObject<IEnumerable<AnnouncementResponse>>(responseBody)!;
                return Result<IEnumerable<AnnouncementResponse>>.Succeeded(response);
            }
            else
            {
                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result<IEnumerable<AnnouncementResponse>>.Failure(error);
            }
        }

        public async Task<Result<IEnumerable<AnnouncementResponse>>> GetUserAnnouncements()
        {
            await AttachBearerToken();
            var result = await HttpClient.GetAsync("Announcement/User/");

            string responseBody = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                IEnumerable<AnnouncementResponse> response = JsonConvert.DeserializeObject<IEnumerable<AnnouncementResponse>>(responseBody)!;
                return Result<IEnumerable<AnnouncementResponse>>.Succeeded(response);
            }
            else
            {
                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result<IEnumerable<AnnouncementResponse>>.Failure(error);
            }
        }

        public async Task<Result<IEnumerable<AnnouncementResponse>>> GetWaitingAnnouncements()
        {
            await AttachBearerToken();
            var result = await HttpClient.GetAsync("Announcement/Moderator/Waiting/");

            string responseBody = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                IEnumerable<AnnouncementResponse> response = JsonConvert.DeserializeObject<IEnumerable<AnnouncementResponse>>(responseBody)!;
                return Result<IEnumerable<AnnouncementResponse>>.Succeeded(response);
            }
            else
            {
                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result<IEnumerable<AnnouncementResponse>>.Failure(error);
            }
        }

        public async Task<Result> RejectAnnouncement(Guid Id)
        {
            await AttachBearerToken();

            var result = await HttpClient.PostAsJsonAsync<RejectAnnouncementRequest>($"Announcement/Moderator/Verify/Reject/{Id}", new RejectAnnouncementRequest(null));

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
