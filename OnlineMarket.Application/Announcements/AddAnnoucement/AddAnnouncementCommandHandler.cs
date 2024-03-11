using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.DomainErrors.AnnouncementError;
using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.AddAnnoucement
{
    public sealed class AddAnnouncementCommandHandler(IAnnoucementRepository _announcementRepository, IUserRepository _userRepository)
        : IRequestHandler<AddAnnouncementCommand, Result>
    {
        public async Task<Result> Handle(AddAnnouncementCommand request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Description) || string.IsNullOrEmpty(request.City) || request.Price <= 0)
            {
                return Result.Failure(AnnouncementError.InvalidValue);
            }

            await _announcementRepository.AddAsync(new Announcement(
                await _userRepository.GetById(request.UserId),
                request.Description,
                request.Price,
                request.City
                ));

            return Result.Succeeded();
        }
    }
}
