using MediatR;
using OnlineMarket.Application.Announcements.GetAllAnnouncements;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.GetWaitingAnnouncements
{
    public sealed class GetWaitingAnnouncementsCommandHandler(IAnnoucementRepository _announcementRepository)
        : IRequestHandler<GetWaitingAnnouncementsCommand, Result<IEnumerable<AnnouncementResponse>>>
    {
        public async Task<Result<IEnumerable<AnnouncementResponse>>> Handle(GetWaitingAnnouncementsCommand request, CancellationToken cancellationToken)
        {
            var announcements = await _announcementRepository.GetAllAsync();

            return Result<IEnumerable<AnnouncementResponse>>.Succeeded(ToAnnouncementResponse(announcements.Where(a => a.Status == AnnouncementStatus.Waiting)));
        }

        private IEnumerable<AnnouncementResponse> ToAnnouncementResponse(IEnumerable<Announcement> announcements)
        {
            return announcements.Select(a => new AnnouncementResponse(
                a.Id,
                Guid.Parse(a.User.Id),
                a.AnnouncementCategory.Name,
                a.Description,
                a.Price,
                a.City,
                a.Status,
                a.Note
                ));
        }
    }
}
