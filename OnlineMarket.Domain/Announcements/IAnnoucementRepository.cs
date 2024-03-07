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
        public Task<Result> AddAsync(Annoucement annoucement);
        public Task<Result> UpdateAsync(Annoucement annoucement);
        public Task<Result> RemoveAsync();
        public Task<Result<IEnumerable<Annoucement>>> GetAllAsync();
        public Task<Result<Annoucement>> GetAsync(Guid id);

    }
}
