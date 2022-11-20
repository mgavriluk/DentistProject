using Dentist.Domain.Auth;
using Dentist.Infrastructure.Persistance.Contexts;
using Dentist.Infrastructure.Persistance.DataSeed;
using Microsoft.AspNetCore.Identity;

namespace Dentist.API.Extensions
{
    public static class HostExtensions
    {
        public static async Task SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DentistDbContext>();
                var userManager = services.GetRequiredService<UserManager<User>>();

                await SeedFacade.SeedData(context, userManager);
            }
        }
    }
}
