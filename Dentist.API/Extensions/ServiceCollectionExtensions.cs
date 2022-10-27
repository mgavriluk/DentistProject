using Dentist.Application;
using Dentist.Application.Extensions;
using Dentist.Application.Profiles;
using Dentist.Infrastructure.Persistance.Extensions;

namespace Dentist.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(ServiceProfile));
            builder.Services.AddApplication();
            builder.Services.AddSwaggerGen();
        }
    }
}
