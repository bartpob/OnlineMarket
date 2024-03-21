using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.GetAllAnnouncements
{
    public sealed class GetAllAnnouncementsQueryHandler(IAnnoucementRepository _announcementRepository)
        : IRequestHandler<GetAllAnnouncementsQuery, Result<IEnumerable<AnnouncementResponse>>>
    {
        public async Task<Result<IEnumerable<AnnouncementResponse>>> Handle(GetAllAnnouncementsQuery request, CancellationToken cancellationToken)
        {
            var announcements = await _announcementRepository.GetAllAsync();

            return Result<IEnumerable<AnnouncementResponse>>.Succeeded(ToAnnouncementResponse(announcements.Where(a => a.Status == AnnouncementStatus.Accepted)));
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
