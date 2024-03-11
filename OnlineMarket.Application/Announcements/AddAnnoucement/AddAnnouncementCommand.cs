using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.AddAnnoucement
{
    public sealed record AddAnnouncementCommand(Guid UserId, string Description, decimal Price, string City)
        : IRequest<Result>;
}
