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
        public Task AddAsync(Announcement annoucement);
        public Task UpdateAsync(Announcement annoucement);
        public Task RemoveAsync(Guid Id);
        public Task<IEnumerable<Announcement>> GetAllAsync();
        public Task<Announcement> GetByIdAsync(Guid id);

    }
}
