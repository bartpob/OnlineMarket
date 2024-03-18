using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.DomainErrors.ConversationErrors
{
    public static class ConversationErrors
    {
        public static readonly Error ConversationNotExists = new Error("CONVERSATION_NOT_EXISTS");
        public static readonly Error ForbiddenAccess = new Error("FORBIDDEN_ACCESS", "Given conversation doesn't belong to current user");
        public static readonly Error ConversationAlreadyExists = new Error("CONVERSATION_ALREADY_EXISTS");
        public static readonly Error AnnouncementExpired = new Error("ANNOUNCEMENT_EXPIRED", "Given announcement is expired, it's impossible to start new conversation");
        public static readonly Error ConversationWithYourself = new Error("CONVERSATION_WITH_YOURSELF", "It's impossible to start new conversation to own announcement");
    }
}
