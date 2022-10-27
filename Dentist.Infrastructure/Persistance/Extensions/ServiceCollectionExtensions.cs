using Dentist.Application.Common.Interfaces;
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

            services.AddScoped<IRepository, GenericRepository>();

            return services;
        }
    }
}
