using MediatR;
using OnlineMarket.Application.Conversations.GetConversation;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Conversations.GetAllConversations
{
    public sealed record GetAllConversationsQuery(Guid UserId)
        : IRequest<Result<IEnumerable<ConversationResponse>>>;
}
