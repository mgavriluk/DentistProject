using Dentist.Infrastructure.Persistance.Contexts;

namespace Dentist.Infrastructure.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(DentistDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
