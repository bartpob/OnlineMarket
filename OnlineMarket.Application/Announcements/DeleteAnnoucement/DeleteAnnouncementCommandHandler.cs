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
            if(await _announcementRepository.GetByIdAsync(request.Id) == null)
            {
                return Result.Failure(AnnouncementError.AnnouncementNotExists);
            }

            await _announcementRepository.RemoveAsync(request.Id);

            return Result.Succeeded();
        }
    }
}
