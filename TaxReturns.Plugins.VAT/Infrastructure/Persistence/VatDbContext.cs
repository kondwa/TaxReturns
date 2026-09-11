using Microsoft.EntityFrameworkCore;
using TaxReturns.Plugins.Abstractions.Application.Models.Enums;
using TaxReturns.Plugins.Abstractions.Infrastructure.Persistence;
using TaxReturns.Plugins.VAT.Domain.Entities;

namespace TaxReturns.Plugins.VAT.Infrastructure.Persistence
{
    public sealed class VatDbContext : TaxPluginDbContext
    {
        public VatDbContext(DbContextOptions<VatDbContext> options): base(options)
        {
        }
        public override TaxType TaxType => TaxType.VAT; 
        public DbSet<VatReturn> Returns => Set<VatReturn>();

        public DbSet<VatPenalty> Penalties => Set<VatPenalty>();

        public DbSet<VatPayment> Payments => Set<VatPayment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(VatDbContext).Assembly);
        }
    }
}
