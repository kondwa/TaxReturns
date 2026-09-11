using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxReturns.Plugins.VAT.Domain.Entities;

namespace TaxReturns.Plugins.VAT.Infrastructure.Configurations
{
    public class VatReturnConfiguration : IEntityTypeConfiguration<VatReturn>
    {
        public void Configure(
        EntityTypeBuilder<VatReturn> builder)
        {
            builder.ToTable("Returns", "vat");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TaxpayerNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Period)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.TaxableAmount)
                .HasPrecision(18, 2);

            builder.Property(x => x.TaxPayable)
                .HasPrecision(18, 2);

            builder.Property(x => x.FiledAtUtc)
                .IsRequired();

            builder.HasIndex(x => new
            {
                x.TaxpayerNumber,
                x.Period
            });
        }
    }
}
