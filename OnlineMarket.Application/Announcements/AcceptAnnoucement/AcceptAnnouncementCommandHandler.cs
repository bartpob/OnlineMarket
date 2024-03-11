using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.DomainErrors.AnnouncementError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.AcceptAnnoucement
{
    public sealed class AcceptAnnouncementCommandHandler(IAnnoucementRepository _announcementRepository)
        : IRequestHandler<AcceptAnnouncementCommand, Result>
    {
        public async Task<Result> Handle(AcceptAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.GetByIdAsync(request.Id);

            if (announcement == null)
            {
                return Result.Failure(AnnouncementError.AnnouncementNotExists);
            }

            announcement.SetStatus(AnnouncementStatus.Accepted);

            await _announcementRepository.UpdateAsync(announcement);

            return Result.Succeeded();
        }
    }
}
