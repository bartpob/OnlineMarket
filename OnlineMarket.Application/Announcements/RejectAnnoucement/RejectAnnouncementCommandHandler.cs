using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.DomainErrors.AnnouncementError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.RejectAnnoucement
{
    public sealed class RejectAnnouncementCommandHandler(IAnnoucementRepository _announcementRepository)
        : IRequestHandler<RejectAnnouncementCommand, Result>
    {
        public async Task<Result> Handle(RejectAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.GetByIdAsync(request.Id);

            if (announcement == null)
            {
                return Result.Failure(AnnouncementError.AnnouncementNotExists);
            }

            announcement.SetStatus(AnnouncementStatus.Rejected);
            announcement.SetNote(request.Note);

            await _announcementRepository.UpdateAsync(announcement);

            return Result.Succeeded();
        }
    }
}
