using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TaxReturns.Plugins.Abstractions.Application.Models.Enums
{
    /// <summary>
    /// Represents the Tax Types available within the authority
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TaxType
    {
        /// <summary>
        /// Digital Services Tax
        /// TODO: This is a temporary code. There is need to get a actual code for the Tax Type from the Domestic Taxes
        /// </summary>
        DST,
        /// <summary>
        /// Value Added Tax
        /// </summary>
        VAT,
        /// <summary>
        /// Withholding Tax
        /// </summary>
        WHT,
        /// <summary>
        /// Pay As You Earn Tax
        /// </summary>
        PAYE
    }
}
