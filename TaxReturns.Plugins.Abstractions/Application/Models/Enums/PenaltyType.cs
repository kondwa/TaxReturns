namespace TaxReturns.Plugins.Abstractions.Application.Models.Enums
{
    public enum PenaltyType
    {
        /// <summary>
        /// Penalty issued when Return was file late
        /// </summary>
        LateFiling,
        /// <summary>
        /// Penalty issued when payment was made late
        /// </summary>
        LatePayment
    }
}