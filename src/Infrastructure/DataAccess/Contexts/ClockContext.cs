using System.Data;
using Domain.DataObjects.Database;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Contexts
{
    public class ClockContext : DbContext
    {
        public virtual DbSet<UserDbo> Users { get; set; }
        
        public virtual DbSet<ClockDbo> Clocks { get; set; }
        public IDbConnection Connection => Database.GetDbConnection();

        public ClockContext()
        {
            
        }

        public ClockContext(DbContextOptions<ClockContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ValidateNullArgument(nameof(modelBuilder));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClockContext).Assembly);
        }
    }
}
