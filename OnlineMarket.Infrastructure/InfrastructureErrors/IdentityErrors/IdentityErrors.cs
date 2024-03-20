using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.InfrastructureErrors.IdentityErrors
{
    public static class IdentityErrors
    {
        public static readonly Error EmailAlreadyTaken = new Error("EMAIL_TAKEN", "Given email is already taken");
        public static readonly Error InvalidEmail = new Error("INVALID_EMAIL", "Given email is not valid address");
        public static readonly Error InvalidPassword = new Error("INVALID_PASSWORD", "Password is invalid.");
        public static readonly Error WrongPassword = new Error("WRONG_PASSWORD", "password is wrong");
        public static readonly Error EmailNotExists = new Error("EMAIL_NOT_EXSITS", "Given email doesn't exist");
        dasdad'salknm
    }
}
