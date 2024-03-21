using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Persistence.Repositories
{
    public class UserRepository
        : IUserRepository
    {
        public Task<User> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
