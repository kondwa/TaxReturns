using System;
using System.Collections.Generic;
using System.Text;
using TaxReturns.Plugins.Abstractions.Application.Models.Enums;

namespace TaxReturns.Plugins.Abstractions.Application.Models
{
    /// <summary>
    /// Represents the result from the plugins
    /// If operation was successful then the result will have the data
    /// If operation was not successful it won't have the data but will have the error details
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OperationResult<T>
    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public T? Data { get; private set; }

        public IReadOnlyCollection<OperationError> Errors { get; private set; }

        private OperationResult(T data)
        {
            IsSuccess = true;
            Data = data;
            Errors = Array.Empty<OperationError>();
        }

        private OperationResult(IEnumerable<OperationError> errors)
        {
            IsSuccess = false;
            Data = default;
            Errors = errors.ToList().AsReadOnly();
        }

        public static OperationResult<T> Success(T data) => new(data);
        public static OperationResult<T> Failure(IEnumerable<OperationError> errors) => new(errors);
        public static OperationResult<T> Failure(OperationError error) => new(new[] { error });
        public static OperationResult<T> Failure(string code, string message, ErrorType type = ErrorType.Transaction) => new(new[] { new OperationError(code, message, type) });
    }
}
