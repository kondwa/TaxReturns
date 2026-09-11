using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxReturns.Plugins.VAT.Domain.Entities;

namespace TaxReturns.Plugins.VAT.Infrastructure.Configurations
{
    public class VatPenaltyConfiguration : IEntityTypeConfiguration<VatPenalty>
    {
        public void Configure(EntityTypeBuilder<VatPenalty> builder)
        {
            builder.ToTable("Penalties", "vat");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TaxpayerNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Period)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.OutstandingAmount)
                .HasPrecision(18, 2);

            builder.Property(x => x.PenaltyAmount)
                .HasPrecision(18, 2);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired();
        }
    }
}
