using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Persistence.Repositories
{
    public class UserRepository(OnlineMarketDbContext _dbContext)
        : IUserRepository
    {
        public async Task<User> GetById(Guid Id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == Id.ToString());
        }
    }
}
