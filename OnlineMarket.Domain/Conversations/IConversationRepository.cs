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
        public Task<Result> AddAsync(Conversation annoucement);
        public Task<Result> UpdateAsync(Conversation annoucement);
        public Task<Result> RemoveAsync();
        public Task<Result<IEnumerable<Conversation>>> GetAllAsync();
        public Task<Result<Conversation>> GetAsync(Guid id);
    }
}
