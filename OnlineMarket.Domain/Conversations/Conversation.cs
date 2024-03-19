using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Conversations
{
    public sealed class Conversation
    {
        private List<Message> _messages = new();

        public Conversation() { }

        public Conversation(Announcement announcement, User sender)
        {
            Announcement = announcement;
            Sender = sender;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public IReadOnlyCollection<Message> Messages => _messages.AsReadOnly();
        public Announcement Announcement { get; private set; }
        public User Sender { get; private set; }
        public void SendMessage(Message message) => _messages.Add(message);
    }
}