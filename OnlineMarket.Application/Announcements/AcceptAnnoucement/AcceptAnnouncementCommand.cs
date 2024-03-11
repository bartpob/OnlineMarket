using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.AcceptAnnoucement
{
    public sealed record AcceptAnnouncementCommand(Guid Id)
        : IRequest<Result>;
}
