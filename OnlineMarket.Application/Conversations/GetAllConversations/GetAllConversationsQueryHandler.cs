using MediatR;
using OnlineMarket.Application.Conversations.GetConversation;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Conversations;
using OnlineMarket.Domain.DomainErrors.UserError;
using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Conversations.GetAllConversations
{
    public sealed class GetAllConversationsQueryHandler(IUserRepository _userRepository, IConversationRepository _conversationRepository)
        : IRequestHandler<GetAllConversationsQuery, Result<IEnumerable<ConversationResponse>>>
    {
        public async Task<Result<IEnumerable<ConversationResponse>>> Handle(GetAllConversationsQuery request, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById(request.UserId) == null)
            {
                return Result<IEnumerable<ConversationResponse>>.Failure(UserError.UserNotExists);
            }
            var conversations = await _conversationRepository.GetAllByUserIdAsync(request.UserId);

            return Result<IEnumerable<ConversationResponse>>.Succeeded(ToConversationResponse(conversations, request.UserId));
        }

        private IEnumerable<ConversationResponse> ToConversationResponse(IEnumerable<Conversation> conversations, Guid userId)
        {
            return conversations.Select(c => new ConversationResponse(
                c.Id,
                c.Announcement.Id,
                ToMessageResponse(c.Messages, userId)
                ));
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
