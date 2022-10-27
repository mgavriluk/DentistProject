using Dentist.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dentist.Infrastructure.Persistance.Configurations
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasMany(b => b.Appointments)
                .WithMany(b => b.Services)
                .UsingEntity(x => x.ToTable("ServicesAppointments"));

            builder.HasOne(b => b.Discount)
                .WithMany(d => d.Services)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
