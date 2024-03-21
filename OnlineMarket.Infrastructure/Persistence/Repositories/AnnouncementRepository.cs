using OnlineMarket.Domain.Announcements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Persistence.Repositories
{
    public class AnnouncementRepository
        : IAnnoucementRepository
    {
        public Task AddAsync(Announcement annoucement)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Announcement>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Announcement> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Announcement annoucement)
        {
            throw new NotImplementedException();
        }
    }
}
