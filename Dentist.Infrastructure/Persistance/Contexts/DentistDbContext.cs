using Dentist.Domain;
using Dentist.Domain.Auth;
using Dentist.Infrastructure.Persistance.Configurations;
using Dentist.Infrastructure.Persistance.Constants;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dentist.Infrastructure.Persistance.Contexts
{
    public class DentistDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ConsultingRoom> ConsultingRooms { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }

        public DentistDbContext(DbContextOptions<DentistDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(DiscountConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            ApplyIdentityMapConfiguration(modelBuilder);
        }

        private void ApplyIdentityMapConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", SchemaConstants.Auth);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims", SchemaConstants.Auth);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins", SchemaConstants.Auth);
            modelBuilder.Entity<UserToken>().ToTable("UserRoles", SchemaConstants.Auth);
            modelBuilder.Entity<Role>().ToTable("Roles", SchemaConstants.Auth);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", SchemaConstants.Auth);
            modelBuilder.Entity<UserRole>().ToTable("UserRole", SchemaConstants.Auth);
        }
    }
}
