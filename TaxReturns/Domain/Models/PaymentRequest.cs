namespace TaxReturns.Domain.Models
{
    public record PaymentRequest(
        string Tpin,
        decimal Amount,
        int[] LiabilityIds,
        string Bank = "STD", string Mode = "CS", bool Sms = true, bool Email = true
    );
}
