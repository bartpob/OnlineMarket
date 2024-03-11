using MediatR;
using Microsoft.Extensions.Logging.Abstractions;
using OnlineMarket.Application.Announcements.GetAllAnnouncements;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.DomainErrors.AnnouncementError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.GetAnnouncement
{
    public sealed class GetAnnouncementQueryHandler(IAnnoucementRepository _announcementRepository)
        : IRequestHandler<GetAnnouncementQuery, Result<AnnouncementResponse>>
    {
        public async Task<Result<AnnouncementResponse>> Handle(GetAnnouncementQuery request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.GetByIdAsync(request.Id);

            if(announcement == null)
            {
                return Result<AnnouncementResponse>.Failure(AnnouncementError.AnnouncementNotExists);
            }

            return Result<AnnouncementResponse>.Succeeded(ToAnnouncementResponse(announcement));
        }

        private AnnouncementResponse ToAnnouncementResponse(Announcement announcement)
        {
            return new AnnouncementResponse(
                announcement.Id,
                Guid.Parse(announcement.User.Id),
                announcement.Description,
                announcement.Price,
                announcement.City,
                announcement.Status,
                announcement.Note
                );
        }
    }
}
