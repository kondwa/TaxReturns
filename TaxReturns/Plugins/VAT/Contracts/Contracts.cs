namespace TaxReturns.Plugins.VAT.Contracts
{
    public sealed record VatFileReturnRequest(
        string TaxpayerNumber,
        string Period,
        decimal TaxableAmount
    );
    public sealed record VatFileReturnResult(
        Guid ReturnId,
        string TaxType,
        string TaxpayerNumber,
        string Period,
        decimal TaxableAmount,
        decimal TaxPayable,
        DateTime FiledAtUtc
    );

    public sealed record VatCalculatePenaltyRequest(
        string TaxpayerNumber,
        string Period,
        decimal OutstandingAmount,
        int DaysLate
    );

    public sealed record VatPenaltyResult(
        Guid PenaltyId,
        string TaxType,
        string TaxpayerNumber,
        string Period,
        decimal OutstandingAmount,
        decimal PenaltyAmount,
        int DaysLate,
        DateTime CreatedAtUtc
    );
    public sealed record VatProcessPaymentRequest(
        string TaxpayerNumber,
        string ReferenceNumber,
        decimal Amount
     );
    public sealed record VatPaymentResult(
        Guid PaymentId,
        string TaxType,
        string TaxpayerNumber,
        string ReferenceNumber,
        decimal Amount,
        DateTime ReceivedAtUtc
    );
}
