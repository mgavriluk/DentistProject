using Dentist.Application.Profiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Dentist.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceProfile));

            return services;
        }
    }
}
