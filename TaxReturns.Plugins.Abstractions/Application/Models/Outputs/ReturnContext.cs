using TaxReturns.Plugins.Abstractions.Application.Models.Enums;

namespace TaxReturns.Plugins.Abstractions.Application.Models.Outputs
{
    public class ReturnContext
    {
        public string TIN { get; set; } = string.Empty;
        public TaxType TaxType { get; set; }
        public required TaxPeriod TaxPeriod { get; set; }
    }
}