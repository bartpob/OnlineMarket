using OnlineMarket.Domain.Conversations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Persistence.Repositories
{
    public class ConversationRepository
        : IConversationRepository
    {
        public Task AddAsync(Conversation annoucement)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Conversation>> GetAllByUserIdAsync(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public Task<Conversation> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Conversation annoucement)
        {
            throw new NotImplementedException();
        }
    }
}
