using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Authentication
{
    public interface IAuthenticationService
    {
        public Task<string> GenerateTokenAsync(User user);
    }
}
