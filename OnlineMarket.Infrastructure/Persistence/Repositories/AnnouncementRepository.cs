using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Persistence.Repositories
{
    public class AnnouncementRepository(OnlineMarketDbContext _dbContext)
        : IAnnoucementRepository
    {
        public async Task AddAsync(Announcement announcement)
        {
            await _dbContext.Announcements.AddAsync(announcement);
        }

        public async Task<IEnumerable<Announcement>> GetAllAsync()
        {
            return await _dbContext.Announcements.ToListAsync();
        }

        public async Task<Announcement> GetByIdAsync(Guid id)
        {
            return await _dbContext.Announcements.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task RemoveAsync(Guid id)
        {
            var announcement = await GetByIdAsync(id);

            _dbContext.Announcements.Remove(announcement);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Announcement announcement)
        {
            _dbContext.Entry(announcement).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
    }
}
