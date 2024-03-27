using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository(OnlineMarketDbContext _dbContext) : ICategoryRepository
    {
        public async Task AddAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _dbContext.Categories.ToListAsync();

            return categories.Where(c => _dbContext.Entry(c).Property("CategoryId").CurrentValue == null).ToList();
        }

        public async Task<Category?> GetByIdAsync(Guid Id)
        {
            return await _dbContext.Categories.Include(c => c.SubCategories).FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<Category?> GetByNameAsync(string Name)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == Name);
        }

        public async Task RemoveAsync(Guid Id)
        {
            var category = await _dbContext.Categories.Include(c => c.SubCategories).FirstOrDefaultAsync(c => c.Id == Id);

            if (category.SubCategories.Any())
            {
                foreach (var cat in category.SubCategories)
                {
                    _dbContext.Entry(cat).State = EntityState.Deleted;
                }
            }
            _dbContext.Categories.Remove(category!);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;

            foreach(var item in category.SubCategories)
            {
                _dbContext.Entry(item).State = EntityState.Added;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
