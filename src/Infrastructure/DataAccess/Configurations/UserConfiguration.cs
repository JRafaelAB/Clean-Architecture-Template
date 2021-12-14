using Domain.Entities;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ValidateNullArgument(nameof(builder));

            builder.ToTable("Users");
            
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Login).IsUnique();
            builder.Property(user => user.Login).IsRequired();
            builder.Property(user => user.Name).IsRequired();
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.Salt).IsRequired();

            builder.HasMany(user => user.Clocks)
                .WithOne(clock => clock.User!)
                .HasForeignKey(clock => clock.IdUser)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
