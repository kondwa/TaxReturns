using System;
using System.Collections.Generic;
using System.Text;

namespace TaxReturns.Plugins.Abstractions.Application.Models.Outputs
{
    /// <summary>
    /// Represents the Tax Period for a return
    /// </summary>
    public class TaxPeriod
    {
        /// <summary>
        /// The Tax Month for the return.
        /// Depends on Implementation. Somne can put 1 for April (as the government financial year commences in April) and others can just put April while others can put 4.
        /// </summary>
        public required string TaxMonth { get; set; }

        /// <summary>
        /// The Tax Year for the Return
        /// </summary>
        public required string TaxYear { get; set; }
    }
}
