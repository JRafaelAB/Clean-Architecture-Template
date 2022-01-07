using Domain.Constants;
using Domain.DataObjects.Database;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<UserDbo>
    {
        public void Configure(EntityTypeBuilder<UserDbo> builder)
        {
            builder.ValidateNullArgument(nameof(builder));

            builder.ToTable(TableNames.UserTable);
            
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Login).IsUnique();
            builder.Property(user => user.Login).IsRequired();
            builder.Property(user => user.Name).IsRequired();
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.Salt).IsRequired();
        }
    }
}
