using Dentist.Domain;
using Dentist.Infrastructure.Persistance.Contexts;

namespace Dentist.Infrastructure.Persistance.DataSeed
{
    public class ConsultingRoomsSeed
    {
        public static async Task Seed(DentistDbContext context)
        {
            if (!context.ConsultingRooms.Any())
            {
                var consultingRoomOnChernovola = new ConsultingRoom()
                {
                    City = "Одесса",
                    Street = "Черновола",
                    HouseNumber = "14"
                };

                context.ConsultingRooms.Add(consultingRoomOnChernovola);

                await context.SaveChangesAsync();
            }
        }
    }
}
