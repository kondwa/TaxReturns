namespace TaxReturns.Plugins.VAT.Domain.Entities
{
    public sealed class VatPayment
    {
        private VatPayment()
        {
        }

        public VatPayment(
            string taxpayerNumber,
            string referenceNumber,
            decimal amount)
        {
            Id = Guid.NewGuid();
            TaxpayerNumber = taxpayerNumber;
            ReferenceNumber = referenceNumber;
            Amount = amount;
            ReceivedAtUtc = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }

        public string TaxpayerNumber { get; private set; } = null!;

        public string ReferenceNumber { get; private set; } = null!;

        public decimal Amount { get; private set; }

        public DateTime ReceivedAtUtc { get; private set; }
    }

}
