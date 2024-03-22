using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.AddAnnoucement
{
    public sealed record AddAnnouncementCommand(Guid UserId, Guid CategoryId, string Header, string Description, decimal Price, string City)
        : IRequest<Result>;
    
    public sealed record AddAnnouncementRequest(Guid CategoryId, string Header, string Description, decimal price, string City);
}
