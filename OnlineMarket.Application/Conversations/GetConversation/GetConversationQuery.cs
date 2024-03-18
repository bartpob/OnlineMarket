using MediatR;
using OnlineMarket.Application.Conversations.SendMessage;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Conversations.GetConversation
{
    public sealed record GetConversationQuery(Guid ConversationId, Guid UserId)
        : IRequest<Result<ConversationResponse>>;

    public sealed record MessageResponse(bool Outgoing, DateTime MessageDate, string Text);
    public sealed record ConversationResponse(Guid ConversationId, Guid AnnouncementId, IReadOnlyCollection<MessageResponse> Messages);
}
