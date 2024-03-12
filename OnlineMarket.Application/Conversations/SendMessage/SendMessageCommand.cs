using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Conversations.SendMessage
{
    public sealed record SendMessageCommand(Guid ConversationId, Guid SenderId, string Text)
        : IRequest<Result>;

    public sealed record SendMessageRequest(Guid ConversationId, string Text);
}
