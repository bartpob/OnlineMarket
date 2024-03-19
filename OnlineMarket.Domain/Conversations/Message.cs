using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Conversations
{
    public sealed class Message
    {
        public Message() { }
        public Message(DateTime date, string text, User sender)
        {
            Date = date;
            Text = text;
            Sender = sender;
        }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime Date { get; private set; }
        public string Text { get; private set; }
        public User Sender { get; private set; }
    }
}
