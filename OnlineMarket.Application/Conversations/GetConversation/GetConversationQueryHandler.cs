using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Conversations;
using OnlineMarket.Domain.DomainErrors.ConversationErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Conversations.GetConversation
{
    public sealed class GetConversationQueryHandler(IConversationRepository _conversationRepository)
        : IRequestHandler<GetConversationQuery, Result<ConversationResponse>>
    {
        public async Task<Result<ConversationResponse>> Handle(GetConversationQuery request, CancellationToken cancellationToken)
        {
            var conversation = await _conversationRepository.GetByIdAsync(request.ConversationId);

            if(conversation == null)
            {
                return Result<ConversationResponse>.Failure(ConversationErrors.ConversationNotExists);
            }

            if(conversation.Announcement.User.Id != request.UserId.ToString() || conversation.Sender.Id != request.UserId.ToString())
            {
                return Result<ConversationResponse>.Failure(ConversationErrors.ForbiddenAccess);
            }

            return Result<ConversationResponse>.Succeeded(ToConversationResponse(conversation, request.UserId));
        }


        private ConversationResponse ToConversationResponse(Conversation conversation, Guid userId)
        {
            return new ConversationResponse(
                conversation.Id,
                conversation.Announcement.Id,
                ToMessageResponse(conversation.Messages, userId)
                );
        }

        private IReadOnlyCollection<MessageResponse> ToMessageResponse(IReadOnlyCollection<Message> messages, Guid userId)
        {
            return messages.Select(m => new MessageResponse(
                m.Sender.Id.Equals(userId) ? true : false,
                m.Date,
                m.Text
                )).ToList().AsReadOnly();
        }
    }
}
