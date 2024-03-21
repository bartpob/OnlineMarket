using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Categories;
using OnlineMarket.Domain.Conversations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Persistence.Repositories
{
    public class ConversationRepository(OnlineMarketDbContext _dbContext)
        : IConversationRepository
    {
        public async Task AddAsync(Conversation conversation)
        {
            await _dbContext.Conversations.AddAsync(conversation);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Conversation>> GetAllByUserIdAsync(Guid UserId)
        {
            return await _dbContext.Conversations.Where(c => c.Sender.Id == UserId.ToString() || c.Announcement.User.Id == UserId.ToString()).ToListAsync();
        }

        public async Task<Conversation> GetByIdAsync(Guid id)
        {
            return await _dbContext.Conversations.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Conversation conversation)
        {
            _dbContext.Entry(conversation).State = EntityState.Modified;

            foreach (var item in conversation.Messages)
            {
                _dbContext.Entry(item).State = EntityState.Added;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
