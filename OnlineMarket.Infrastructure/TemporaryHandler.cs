using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.Categories;
using OnlineMarket.Domain.Conversations;
using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure
{
    public class TemporaryHandler : IConversationRepository, IAnnoucementRepository, ICategoryRepository, IUserRepository
    {
        public Task AddAsync(Conversation annoucement)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Announcement annoucement)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task AddSubCategory(Guid Id, Category category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Announcement>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Conversation>> GetAllByUserIdAsync(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Conversation> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Conversation annoucement)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Announcement annoucement)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Category>> ICategoryRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Announcement> IAnnoucementRepository.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Category?> ICategoryRepository.GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
