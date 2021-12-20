using Domain.Constants;
using Domain.DataObjects.Database;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    public sealed class ClockConfiguration : IEntityTypeConfiguration<ClockDbo>
    {
        public void Configure(EntityTypeBuilder<ClockDbo> builder)
        {
            builder.ValidateNullArgument(nameof(builder));

            builder.ToTable(TableNames.ClockTable);
            
            builder.HasKey(clock => clock.Id);
            builder.HasIndex(clock => clock.IdUser);
            builder.Property(clock => clock.Time).IsRequired();
            builder.Property(clock => clock.Type).IsRequired();
        }
    }
}
