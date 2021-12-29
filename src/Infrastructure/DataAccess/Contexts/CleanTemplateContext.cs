using System.Data;
using Domain.DataObjects.Database;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Contexts
{
    public class CleanTemplateContext : DbContext
    {
        public virtual DbSet<UserDbo> Users { get; set; }
        public IDbConnection Connection => Database.GetDbConnection();

        public CleanTemplateContext()
        {
            
        }

        public CleanTemplateContext(DbContextOptions<CleanTemplateContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ValidateNullArgument(nameof(modelBuilder));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanTemplateContext).Assembly);
        }
    }
}
