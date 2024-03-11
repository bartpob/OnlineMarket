using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Users
{
    public interface IUserRepository
    {
        public Task<User> GetById(Guid Id);
    }
}
