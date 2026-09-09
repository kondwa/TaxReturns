using Microsoft.EntityFrameworkCore;
using TaxReturns.Plugins.VAT.Domain.Entities;

namespace TaxReturns.Plugins.VAT.Infrastructure.Persistence
{
    public class VatDbContext:DbContext
    {
        public VatDbContext(DbContextOptions<VatDbContext> options) : base(options)
        {
        }
        public DbSet<VatReturn> Returns => Set<VatReturn>();

        public DbSet<VatPenalty> Penalties => Set<VatPenalty>();

        public DbSet<VatPayment> Payments => Set<VatPayment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("vat");

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(VatDbContext).Assembly);
        }
    }
}
