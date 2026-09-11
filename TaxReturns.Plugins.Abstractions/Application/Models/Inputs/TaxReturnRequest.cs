
using System;
using System.Collections.Generic;
using System.Text;
using TaxReturns.Plugins.Abstractions.Application.Models.Enums;
using TaxReturns.Plugins.Abstractions.Application.Models.Outputs;

namespace TaxReturns.Plugins.Abstractions.Application.Models.Inputs
{
    /// <summary>
    /// Represents the Base Class for a Tax Return Request
    /// Used when a Taxpayer is submitting a return
    /// </summary>
    public class TaxReturnRequest
    {
        /// <summary>
        /// The Taxpayer Identification Number for the Taxpayer submitting the return
        /// </summary>
        public required string TIN { get; set; }

        /// <summary>
        /// The Tax Type for the return
        /// </summary>
        public required TaxType TaxType { get; set; }

        /// <summary>
        /// The Tax Period
        /// This will be specific to the Tax Type. Some Tax Types can specify April/2026 while others can specify 1/2027
        /// </summary>
        public required TaxPeriod TaxPeriod { get; set; }
        /// <summary>
        /// Indicates whether the taxpayer has acknowledged the declaration for the tax return.
        /// </summary>
        public required bool DeclarationAcknowledged { get; set; }
        public required DateTime SubmissionDate { get; set; }
    }
}
