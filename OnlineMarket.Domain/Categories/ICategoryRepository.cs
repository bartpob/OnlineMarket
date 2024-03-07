using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Categories
{
    public interface ICategoryRepository
    {
        public Task<Result> AddAsync(Category category);
        public Task<Result> UpdateAsync(Category category);
        public Task<Result> RemoveAsync(Guid Id);
        public Task<Result<IEnumerable<Category>>> GetAllAsync();
        public Task<Result<Category>> GetByIdAsync(Guid id);
    }
}
