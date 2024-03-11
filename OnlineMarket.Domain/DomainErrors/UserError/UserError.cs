using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.DomainErrors.UserError
{
    public static class UserError
    {
        public static Error UserNotExists = new Error("USER_NOT_EXISTS");
    }
}
