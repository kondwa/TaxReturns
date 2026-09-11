using TaxReturns.Plugins.Abstractions.Application.Models.Enums;
using TaxReturns.Plugins.Abstractions.Application.Models.Outputs;

namespace TaxReturns.Plugins.VAT.Domain.Models
{
    public class VatTaxReturn:TaxReturn
    {
        public string TIN { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal TaxRate { get; set; }
        public TaxType TaxType { get; set; }
        public ReturnStatus Status { get; set; }
        public required TaxPeriod TaxPeriod { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
    }
}
