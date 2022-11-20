using Dentist.Application.Common.Interfaces;
using Dentist.Domain.Auth;
using Dentist.Infrastructure.Identity;
using Dentist.Infrastructure.Persistance.Contexts;
using Dentist.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dentist.Infrastructure.Persistance.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<DentistDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(configuration.GetConnectionString("DentistDb"));
            });

            services.AddIdentity<User, Role>(optionBuilder =>
            {
                optionBuilder.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<DentistDbContext>();

            services.AddScoped<IRepository, GenericRepository>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}
