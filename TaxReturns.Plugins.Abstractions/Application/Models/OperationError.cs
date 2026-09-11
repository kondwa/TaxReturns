using System;
using System.Collections.Generic;
using System.Text;
using TaxReturns.Plugins.Abstractions.Application.Models.Enums;

namespace TaxReturns.Plugins.Abstractions.Application.Models
{
    public class OperationError
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public ErrorType Type { get; set; } = ErrorType.Validation;

        /// <summary>
        /// Optional target (e.g., field name for validation errors, or component name for transaction errors).
        /// </summary>
        public string? Target { get; set; }

        public OperationError() { }

        public OperationError(string code, string message, ErrorType type = ErrorType.Validation, string? target = null)
        {
            Code = code;
            Message = message;
            Type = type;
            Target = target;
        }

        #region Convenience Helper Methods

        public static OperationError Validation(string code, string message, string? field = null)
            => new(code, message, ErrorType.Validation, field);

        public static OperationError Transaction(string code, string message, string? component = null)
            => new(code, message, ErrorType.Transaction, component);

        public static OperationError BusinessRule(string code, string message)
            => new(code, message, ErrorType.BusinessRule);

        #endregion
    }
}
