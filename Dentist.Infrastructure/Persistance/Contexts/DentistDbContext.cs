using Dentist.Domain;
using Dentist.Infrastructure.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Dentist.Infrastructure.Persistance.Contexts
{
    public class DentistDbContext : DbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Appointment> Appointments { get; set; }
        DbSet<ConsultingRoom> ConsultingRooms { get; set; }
        DbSet<PhoneNumber> PhoneNumbers { get; set; }
        DbSet<WorkingTime> WorkingTimes { get; set; }

        public DentistDbContext(DbContextOptions<DentistDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(DiscountConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
