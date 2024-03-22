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
    public sealed record GetAllAnnouncementsQuery
        : IRequest<Result<IEnumerable<AnnouncementResponse>>>;

    public sealed record AnnouncementResponse(Guid Id, Guid UserId, string categoryName, string header, string Description, decimal Price, string City, AnnouncementStatus Status, string? Note);
}
