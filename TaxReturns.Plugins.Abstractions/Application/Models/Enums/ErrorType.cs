using System;
using System.Collections.Generic;
using System.Text;

namespace TaxReturns.Plugins.Abstractions.Application.Models.Enums
{
    public enum ErrorType
    {
        /// <summary>
        /// Input data rule violation (e.g., negative amount, missing mandatory field).
        /// </summary>
        Validation = 1,

        /// <summary>
        /// Business rule or domain logic failure (e.g., filing closed for period, duplicate submission).
        /// </summary>
        BusinessRule = 2,

        /// <summary>
        /// Transaction/Infrastructure issue (e.g., ledger lock timeout, DB error, payment gateway failure).
        /// </summary>
        Transaction = 3,

        /// <summary>
        /// Unauthorized access or invalid TIN matching.
        /// </summary>
        Security = 4
    }
}
