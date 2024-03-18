using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.Conversations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.Domain.DomainErrors.AnnouncementError;
using OnlineMarket.Domain.DomainErrors.ConversationErrors;
using OnlineMarket.Domain.Users;

namespace OnlineMarket.Application.Conversations.StartNewConversation
{
    public sealed class StartNewConversationCommandHandler(IConversationRepository _conversationRepository, 
        IAnnoucementRepository _announcementRepository, 
        IUserRepository _userRepository)
        : IRequestHandler<StartNewConversationCommand, Result>
    {
        public async Task<Result> Handle(StartNewConversationCommand request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.GetByIdAsync(request.AnnouncementId);
            var user = await _userRepository.GetById(request.SenderId);

            if (await isConversationExists(user, request.AnnouncementId))
            {
                return Result.Failure(ConversationErrors.ConversationAlreadyExists);
            }

            if (announcement == null)
            {
                return Result.Failure(AnnouncementError.AnnouncementNotExists);
            }

            if (announcement.User.Id == request.SenderId.ToString())
            {
                return Result.Failure(ConversationErrors.ConversationWithYourself);
            }

            var conversation = new Conversation
                (
                announcement,
                user
                );
            conversation.SendMessage(new Message(
                DateTime.Now,
                request.Text,
                user
                ));

            await _conversationRepository.AddAsync(conversation);

            return Result.Succeeded();
        }

        private async Task<bool> isConversationExists(User user, Guid announcementId)
        {
            var conversations = await _conversationRepository.GetAllByUserIdAsync(Guid.Parse(user.Id));
            
            foreach(var conversation in conversations)
            {
                if(conversation.Announcement.Id == announcementId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
