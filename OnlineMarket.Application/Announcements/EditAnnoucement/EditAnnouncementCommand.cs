﻿using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.EditAnnoucement
{
    public sealed record EditAnnouncementCommand(Guid Id, Guid UserId, string Description, decimal Price, string City)
        : IRequest<Result>;
}
