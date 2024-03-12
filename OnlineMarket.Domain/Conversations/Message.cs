using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Conversations
{
    public sealed record Message(DateTime Date, string Text, User Sender);
}
