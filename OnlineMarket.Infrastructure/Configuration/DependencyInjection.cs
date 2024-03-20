using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.Categories;
using OnlineMarket.Domain.Conversations;
using OnlineMarket.Domain.Users;
using OnlineMarket.Infrastructure.Authentication;
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

            services.ConfigureAuthentication(configuration);

            services.ConfigureMediatR();


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


        private static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(assembly);
            });

            return services;
        }
        
        private static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!))
                };
            });

            return services;
        }
    }
}
