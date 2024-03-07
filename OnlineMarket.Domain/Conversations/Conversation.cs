using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Conversations
{
    public sealed class Conversation(Annoucement annoucement, User sender)
    {
        private List<Message> _messages = new();

        public Guid Id;
        public IReadOnlyCollection<Message> Messages => _messages.AsReadOnly();
        public Annoucement Annoucement { get; init; } = annoucement;
        public User Sender { get; init; } = sender;
        public void AddMessage(Message message) => _messages.Add(message);
    }
}
