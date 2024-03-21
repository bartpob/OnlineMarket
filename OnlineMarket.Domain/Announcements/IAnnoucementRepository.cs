using Microsoft.EntityFrameworkCore.Migrations.Operations;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Announcements
{
    public interface IAnnoucementRepository
    {
        public Task AddAsync(Announcement announcement);
        public Task UpdateAsync(Announcement announcement);
        public Task RemoveAsync(Guid id);
        public Task<IEnumerable<Announcement>> GetAllAsync();
        public Task<Announcement> GetByIdAsync(Guid id);

    }
}
