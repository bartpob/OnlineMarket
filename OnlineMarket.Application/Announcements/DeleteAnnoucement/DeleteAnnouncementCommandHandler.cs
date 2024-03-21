using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.DomainErrors.AnnouncementError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.DeleteAnnoucement
{
    public sealed class DeleteAnnouncementCommandHandler(IAnnoucementRepository _announcementRepository)
        : IRequestHandler<DeleteAnnouncementCommand, Result>
    {
        public async Task<Result> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.GetByIdAsync(request.Id);

            if (announcement == null)
            {
                return Result.Failure(AnnouncementError.AnnouncementNotExists);
            }

            if(announcement.User.Id != request.userId.ToString())
            {
                return Result.Failure(AnnouncementError.TriedEditForeignAnnouncement);
            }

            await _announcementRepository.RemoveAsync(request.Id);

            return Result.Succeeded();
        }
    }
}
