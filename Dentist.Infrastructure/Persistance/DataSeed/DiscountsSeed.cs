using Dentist.Domain;
using Dentist.Infrastructure.Persistance.Contexts;

namespace Dentist.Infrastructure.Persistance.DataSeed
{
    public class DiscountsSeed
    {
        public static async Task Seed(DentistDbContext context)
        {
            if (!context.Discounts.Any())
            {
                var zsu = new Discount()
                {
                    Name = "Скидка для ЗСУ",
                    DiscountPercentage = 20,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(2),
                };

                var pensoiner = new Discount()
                {
                    Name = "Скидка для пенсионеров",
                    DiscountPercentage = 25,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1)
                };

                context.Discounts.Add(zsu);
                context.Discounts.Add(pensoiner);

                await context.SaveChangesAsync();
            }
        }
    }
}
