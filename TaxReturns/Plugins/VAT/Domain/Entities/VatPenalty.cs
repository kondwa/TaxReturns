namespace TaxReturns.Plugins.VAT.Domain.Entities
{
    public sealed class VatPenalty
    {
        private VatPenalty()
        {
        }

        public VatPenalty(
            string taxpayerNumber,
            string period,
            decimal outstandingAmount,
            decimal penaltyAmount,
            int daysLate)
        {
            Id = Guid.NewGuid();
            TaxpayerNumber = taxpayerNumber;
            Period = period;
            OutstandingAmount = outstandingAmount;
            PenaltyAmount = penaltyAmount;
            DaysLate = daysLate;
            CreatedAtUtc = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }

        public string TaxpayerNumber { get; private set; } = null!;

        public string Period { get; private set; } = null!;

        public decimal OutstandingAmount { get; private set; }

        public decimal PenaltyAmount { get; private set; }

        public int DaysLate { get; private set; }

        public DateTime CreatedAtUtc { get; private set; }
    }

}
