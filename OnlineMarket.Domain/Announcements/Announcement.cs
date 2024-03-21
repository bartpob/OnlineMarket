using OnlineMarket.Domain.Categories;
using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Announcements
{
    public sealed class Announcement
    {
        public Announcement() { }
        public Announcement(User user, Category category, string description, decimal price, string city)
        {
            User = user;
            Description = description;
            Price = price;
            City = city;
            AnnouncementCategory = category;
        }


        public Guid Id { get; private set; }
        public User User { get; private set; }
        public Category AnnouncementCategory { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string City { get; private set; }
        public AnnouncementStatus Status { get; private set; } = AnnouncementStatus.Waiting;
        public string? Note { get; private set; } = string.Empty!;

        public void SetStatus(AnnouncementStatus status)
        {
            Status = status;
        }

        public void SetNote(string? note)
        {
            Note = note;    
        }

        public void Update(string description, Category category, decimal price, string city)
        {
            Description = description;
            Price = price;
            City = city;
            AnnouncementCategory = category;
        }
       
    }
}
