using Dentist.Domain;
using Dentist.Infrastructure.Persistance.Contexts;

namespace Dentist.Infrastructure.Persistance.DataSeed
{
    public class ServicesSeed
    {
        public static async Task Seed(DentistDbContext context)
        {
            if (!context.Services.Any())
            {
                var profGigiena = new Service()
                {
                    Title = "Профессиональная гигиена",
                    Price = 1000
                };

                var restavration = new Service()
                {
                    Title = "Реставрация",
                    Price = 1000
                };

                var hardRestavration = new Service()
                {
                    Title = "Сложная реставрация",
                    Price = 1500
                };

                var kornevoyKanal = new Service()
                {
                    Title = "Лечение корневых каналов (1 канал)",
                    Price = 600
                };

                var anesteziya = new Service()
                {
                    Title = "Анестезия",
                    Price = 200
                };

                var metallKoronka = new Service()
                {
                    Title = "Металло-керамическая коронка",
                    Price = 120
                };

                var bezMetallKoronka = new Service()
                {
                    Title = "Безметалловая коронка",
                    Price = 300
                };

                var metllBreket = new Service()
                {
                    Title = "Металлическая брекет-система (1 челюсть)",
                    Price = 350
                };

                var keramBreket = new Service()
                {
                    Title = "Керамическая брекет-система (1 челюсть)",
                    Price = 700
                };

                var udaleniye = new Service()
                {
                    Title = "Удаление (простое)",
                    Price = 750
                };

                var udaleniyeSlojn = new Service()
                {
                    Title = "Удаление (сложное)",
                    Price = 1250
                };

                var implant = new Service()
                {
                    Title = "Имплантация (система B&B Италия)",
                    Price = 400
                };

                context.Services.Add(profGigiena);
                context.Services.Add(restavration);
                context.Services.Add(hardRestavration);
                context.Services.Add(kornevoyKanal);
                context.Services.Add(anesteziya);
                context.Services.Add(metallKoronka);
                context.Services.Add(bezMetallKoronka);
                context.Services.Add(metllBreket);
                context.Services.Add(keramBreket);
                context.Services.Add(udaleniye);
                context.Services.Add(udaleniyeSlojn);
                context.Services.Add(implant);

                await context.SaveChangesAsync();
            }
        }
    }
}
