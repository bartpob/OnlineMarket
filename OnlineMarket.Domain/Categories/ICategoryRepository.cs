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
        public Task AddAsync(Category category);
        public Task UpdateAsync(Category category);
        public Task RemoveAsync(Guid Id);
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(Guid Id);
        public Task<Category?> GetByNameAsync(string Name);
    }
}
