using Dentist.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dentist.Infrastructure.Persistance.Configurations
{
    public class DiscountConfig : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasMany(d => d.Services)
                .WithOne(s => s.Discount)
                .HasForeignKey(s => s.DiscountId)
                .OnDelete(DeleteBehavior.SetNull);


            builder.HasMany(d => d.Clients)
                .WithOne(c => c.Discount)
                .HasForeignKey(c => c.DiscountId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
