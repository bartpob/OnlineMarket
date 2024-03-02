using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Users
{
    public sealed class User : IdentityUser
    {
        public string City { get; set; } = default!;
    }
}
