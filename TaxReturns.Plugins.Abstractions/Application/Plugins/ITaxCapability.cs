using TaxReturns.Plugins.Abstractions.Application.Models.Enums;

namespace TaxReturns.Plugins.Abstractions.Application.Plugins
{
    public interface ITaxCapability
    {
        /// <summary>
        /// Unique Tax Type Identifier (e.g., "WHT", "PAYE")
        /// This is the Tax Type that the Plugin is developed to process.
        /// </summary>
        TaxType TaxType { get; }

        /// <summary>
        /// Plugin Version. Kaya ntchito yake ndi chani kaya?
        /// </summary>
        string Version { get; }
        
    }
}
