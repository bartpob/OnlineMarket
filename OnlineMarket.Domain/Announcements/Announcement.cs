using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Announcements
{
    public sealed class Announcement(User user, string description, decimal price, string city)
    {
        public Guid Id { get; private set; }
        public User User { get; private set; } = user;
        public string Description { get; private set; } = description;
        public decimal Price { get; private set; } = price;
        public string City { get; private set; } = city;
        public AnnouncementStatus Status { get; private set; } = AnnouncementStatus.Waiting;
        public string Note { get; private set; } = string.Empty!;

        public void SetStatus(AnnouncementStatus status)
        {
            Status = status;
        }

        public void SetNote(string? note)
        {
            Note = note;
        }

        public void Update(string description, decimal price, string city)
        {
            Description = description;
            Price = price;
            City = city;
        }
       
    }
}
