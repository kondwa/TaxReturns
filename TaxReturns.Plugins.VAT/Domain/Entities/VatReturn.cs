using TaxReturns.Plugins.VAT.Domain.Enums;

namespace TaxReturns.Plugins.VAT.Domain.Entities
{
    public sealed class VatReturn
    {
        private VatReturn()
        {
        }
        public VatReturn(
            string taxpayerNumber,
            string period,
            decimal taxableAmount,
            decimal taxPayable)
        {
            Id = Guid.NewGuid();
            TaxpayerNumber = taxpayerNumber;
            Period = period;
            TaxableAmount = taxableAmount;
            TaxPayable = taxPayable;
            FiledAtUtc = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public string TaxpayerNumber { get; private set; } = null!;
        public string Period { get; private set; } = null!;
        public decimal TaxableAmount { get; private set; }
        public decimal TaxPayable { get; private set; }
        public DateTime FiledAtUtc { get; private set; }
    }
}
