using MediatR;
using OnlineMarket.Application.Announcements.GetAllAnnouncements;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.GetWaitingAnnouncements
{
    public sealed record GetWaitingAnnouncementsCommand
        : IRequest<Result<IEnumerable<AnnouncementResponse>>>;
}
