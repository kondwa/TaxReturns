using TaxReturns.Plugins.Abstractions.Application.Models.Enums;
using TaxReturns.Plugins.Abstractions.Application.Models.Outputs;

namespace TaxReturns.Plugins.VAT.Domain.Models
{
    public class VatTaxAssessment:TaxAssessment
    {
        public decimal TaxAmount { get; set; }
        public decimal TaxRate { get; set; } 
        public TaxType TaxType { get; set; }
        public DateTime AssessmentDate { get; set; } = DateTime.UtcNow;
    }
}
