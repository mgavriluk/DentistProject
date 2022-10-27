using Dentist.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dentist.Infrastructure.Persistance.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.Client)
                 .WithOne(c => c.User)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
