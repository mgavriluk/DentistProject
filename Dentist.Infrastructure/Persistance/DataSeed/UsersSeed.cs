using Dentist.Domain.Auth;
using Microsoft.AspNetCore.Identity;

namespace Dentist.Infrastructure.Persistance.DataSeed
{
    public class UsersSeed
    {
        public static async Task Seed(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                };

                await userManager.CreateAsync(user, "Qwerty1!");
            }
        }
    }
}
