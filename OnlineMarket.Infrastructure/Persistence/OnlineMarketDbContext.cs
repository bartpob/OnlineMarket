using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.Categories;
using OnlineMarket.Domain.Conversations;
using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Persistence
{
    public partial class OnlineMarketDbContext
        : IdentityDbContext<User>
    {
        public OnlineMarketDbContext() { }

        public OnlineMarketDbContext(DbContextOptions<OnlineMarketDbContext> options)
            : base(options) { }

        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Conversation> Conversations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Announcement>()
                .Property(a => a.Price)
                .HasColumnType("DECIMAL(10,2)");

            builder.Entity<User>()
                .Property(u => u.City)
                .IsRequired(false);

            base.OnModelCreating(builder);

            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder builder);
    }
}
