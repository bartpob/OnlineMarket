using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.Categories;
using OnlineMarket.Domain.Conversations;
using OnlineMarket.Domain.Users;
using OnlineMarket.Infrastructure.Persistence;
using OnlineMarket.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("OnlineMarketDbConnection");

            services.AddDbContext<OnlineMarketDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity();

            services.AddSingleton<IConversationRepository, TemporaryHandler>();
            services.AddSingleton<IAnnoucementRepository, TemporaryHandler>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IUserRepository, TemporaryHandler>();

            return services;
        }

        private static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<OnlineMarketDbContext>();


            return services;
        }
    }
}
