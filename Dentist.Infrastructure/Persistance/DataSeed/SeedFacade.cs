using Dentist.Domain.Auth;
using Dentist.Infrastructure.Persistance.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dentist.Infrastructure.Persistance.DataSeed
{
    public class SeedFacade
    {
        public static async Task SeedData(DentistDbContext context, UserManager<User> userManager)
        {
            context.Database.Migrate();

            await UsersSeed.Seed(userManager);
            await ServicesSeed.Seed(context);
            await DiscountsSeed.Seed(context);
            await ConsultingRoomsSeed.Seed(context);
        }
    }
}
