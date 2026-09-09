using System.Runtime.Serialization;

namespace TaxReturns.Domain.Models
{
    public record PostBackData(
        string Prn, 
        string? ReferenceId, 
        decimal Amount, 
        string? Status, 
        string? MRAReceipt, 
        DateTime? DatePaid, 
        string? ReceivingBank, 
        string? ReceivingBankName
     );
}
