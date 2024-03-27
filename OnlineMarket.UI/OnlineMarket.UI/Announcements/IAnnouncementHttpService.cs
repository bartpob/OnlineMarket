using OnlineMarket.Application.Announcements.AddAnnoucement;
using OnlineMarket.Application.Announcements.EditAnnoucement;
using OnlineMarket.Application.Announcements.GetAllAnnouncements;
using OnlineMarket.Domain.Abstractions.Result;

namespace OnlineMarket.UI.Announcements
{
    public interface IAnnouncementHttpService
    {
        public Task<Result> AcceptAnnouncement(Guid Id);
        public Task<Result> RejectAnnouncement(Guid Id);
        public Task<Result<AnnouncementResponse>> GetAnnouncement(Guid Id);
        public Task<Result<IEnumerable<AnnouncementResponse>>> GetAnnouncements();
        public Task<Result<IEnumerable<AnnouncementResponse>>> GetUserAnnouncements();
        public Task<Result<IEnumerable<AnnouncementResponse>>> GetWaitingAnnouncements();
        public Task<Result> DeleteAnnouncement(Guid Id);
        public Task<Result> EditAnnouncement(Guid Id, EditAnnouncementRequest request);
        public Task<Result> AddAnnouncement(AddAnnouncementRequest request);
    }
}
