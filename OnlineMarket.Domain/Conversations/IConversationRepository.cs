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
        public Task AddAsync(Conversation annoucement);
        public Task UpdateAsync(Conversation annoucement);
        public Task<IEnumerable<Conversation>> GetAllByUserIdAsync(Guid UserId);
        public Task<Conversation> GetByIdAsync(Guid id);
    }
}
