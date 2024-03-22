using MediatR;
using OnlineMarket.Application.Conversations.GetConversation;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Conversations;
using OnlineMarket.Domain.DomainErrors.ConversationErrors;
using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Conversations.SendMessage
{
    public sealed class SendMessageCommandHandler(IConversationRepository _conversationRepository, IUserRepository _userRepository)
        : IRequestHandler<SendMessageCommand, Result>
    {
        public async Task<Result> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var conversation = await _conversationRepository.GetByIdAsync(request.ConversationId);

            if(conversation == null)
            {
                return Result.Failure(ConversationErrors.ConversationNotExists);
            }

            if (conversation.Announcement.User.Id != request.SenderId.ToString() && conversation.Sender.Id != request.SenderId.ToString())
            {
                return Result<ConversationResponse>.Failure(ConversationErrors.ForbiddenAccess);
            }
            var user = await _userRepository.GetById(request.SenderId);

            conversation.SendMessage(new Message(
                DateTime.Now,
                request.Text,
                user
                ));

            await _conversationRepository.UpdateAsync(conversation);

            return Result.Succeeded();
        }
    }
}
