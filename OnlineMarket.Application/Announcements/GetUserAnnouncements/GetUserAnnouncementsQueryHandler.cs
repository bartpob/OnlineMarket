using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using OnlineMarket.Application.Announcements.GetAllAnnouncements;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.DomainErrors.UserError;
using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.GetUserAnnouncements
{
    public sealed class GetUserAnnouncementsQueryHandler(IAnnoucementRepository _announcementRepository, IUserRepository _userRepository)
        : IRequestHandler<GetUserAnnouncementsQuery, Result<IEnumerable<AnnouncementResponse>>>
    {
        public async Task<Result<IEnumerable<AnnouncementResponse>>> Handle(GetUserAnnouncementsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.UserId);

            if(user == null)
            {
                Result<IEnumerable<AnnouncementResponse>>.Failure(UserError.UserNotExists);
            }

            var announcements = await _announcementRepository.GetAllAsync();

            var userAnnouncements = announcements.Where(a => a.User.Id == request.UserId.ToString()).ToList();

            return Result<IEnumerable<AnnouncementResponse>>.Succeeded(ToAnnouncementResponse(userAnnouncements));
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
