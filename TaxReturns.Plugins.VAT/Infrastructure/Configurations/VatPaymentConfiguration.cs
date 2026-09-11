using Microsoft.EntityFrameworkCore;
using TaxReturns.Plugins.VAT.Domain.Entities;

namespace TaxReturns.Plugins.VAT.Infrastructure.Configurations
{
    public class VatPaymentConfiguration : IEntityTypeConfiguration<VatPayment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<VatPayment> builder)
        {
            builder.ToTable("Payments", "vat");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TaxpayerNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.ReferenceNumber)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Amount)
                .HasPrecision(18, 2);

            builder.Property(x => x.ReceivedAtUtc)
                .IsRequired();

            builder.HasIndex(x => x.ReferenceNumber);
        }
    }
}
