using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Announcements
{
    public sealed class Annoucement(string description, decimal price, string city)
    {
        public Guid Id { get; init; }
        public string Description { get; init; } = description;
        public decimal Price { get; init; } = price;
        public string City { get; init; } = city;
        public AnnoucementStatus Status { get; private set; } = AnnoucementStatus.Waiting;
        public string Note { get; private set; } = string.Empty;

        public void SetStatus(AnnoucementStatus status)
        {
            Status = status;
        }

        public void SetNote(string note)
        {
            Note = note;
        }
       
    }
}
