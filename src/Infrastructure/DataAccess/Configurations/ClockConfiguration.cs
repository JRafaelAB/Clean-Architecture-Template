using Domain.Entities;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    public sealed class ClockConfiguration : IEntityTypeConfiguration<Clock>
    {
        public void Configure(EntityTypeBuilder<Clock> builder)
        {
            builder.ValidateNullArgument(nameof(builder));

            builder.ToTable("Clocks");
            
            builder.HasKey(clock => clock.Id);
            builder.HasIndex(clock => clock.IdUser);
            builder.Property(clock => clock.Time).IsRequired();
            builder.Property(clock => clock.Type).IsRequired();
        }
    }
}
