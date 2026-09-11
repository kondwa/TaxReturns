using Microsoft.EntityFrameworkCore;
using TaxReturns.Plugins.Abstractions.Application.Models.Enums;

namespace TaxReturns.Plugins.Abstractions.Infrastructure.Persistence
{
    public abstract class TaxPluginDbContext : DbContext
    {   
        protected TaxPluginDbContext(DbContextOptions options) : base(options) { }
        public abstract TaxType TaxType { get; }

        public virtual string DatabaseSchema => TaxType.ToString().ToLowerInvariant();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(DatabaseSchema);
        }
    }
}
