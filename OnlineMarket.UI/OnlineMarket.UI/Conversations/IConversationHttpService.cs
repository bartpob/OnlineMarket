using OnlineMarket.Application.Conversations.GetConversation;
using OnlineMarket.Application.Conversations.SendMessage;
using OnlineMarket.Application.Conversations.StartNewConversation;
using OnlineMarket.Domain.Abstractions.Result;

namespace OnlineMarket.UI.Conversations
{
    public interface IConversationHttpService
    {
        public Task<Result<IEnumerable<ConversationResponse>>> GetConversations();
        public Task<Result<ConversationResponse>> GetConversation(Guid Id);
        public Task<Result> SendMessage(Guid Id, SendMessageRequest request);
        public Task<Result> StartConversation(StartNewConversationRequest request);
    }
}
