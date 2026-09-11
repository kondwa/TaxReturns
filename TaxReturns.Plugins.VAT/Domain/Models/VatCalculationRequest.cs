

using TaxReturns.Plugins.Abstractions.Application.Models.Inputs;

namespace TaxReturns.Plugins.VAT.Domain.Models
{
    public class VatCalculationRequest:CalculationRequest
    {
        public decimal Amount { get; init; }
    }
}
