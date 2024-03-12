using MediatR;
using OnlineMarket.Application.Conversations.SendMessage;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Conversations.StartNewConversation
{
    public sealed record StartNewConversationCommand(Guid AnnouncementId, Guid SenderId, string Text)
        : IRequest<Result>;
}
