﻿using MediatR;
using OnlineMarket.Application.Announcements.GetAllAnnouncements;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.RejectAnnoucement
{
    public sealed record RejectAnnouncementCommand(Guid Id, string? Note)
        : IRequest<Result>;
}
