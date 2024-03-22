using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Conversations
{
    public interface IConversationRepository
    {
        public Task AddAsync(Conversation conversation);
        public Task UpdateAsync(Conversation conversation);
        public Task<Conversation> GetByIdWithMessagesAsync(Guid Id);
        public Task<IEnumerable<Conversation>> GetAllByUserIdAsync(Guid UserId);
        public Task<Conversation> GetByIdAsync(Guid id);
    }
}
