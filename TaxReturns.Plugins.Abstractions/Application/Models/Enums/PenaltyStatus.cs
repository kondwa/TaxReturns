namespace TaxReturns.Plugins.Abstractions.Application.Models.Enums
{
    public enum PenaltyStatus
    {
        /// <summary>
        /// This is Status Number 2 in a Penalty's Life Cycle
        /// Status set on a a Penalty record when a PRN has been generated for that penalty and it is awaiting payment
        /// </summary>
        AwaitingPayment,
        /// <summary>
        /// This is Status Number 3 in a Penalty's Life Cycle
        /// Status set on a Penalty record when its paid
        /// </summary>
        Paid,
        /// <summary>
        /// This is Status Number 1 in a Penalty's Life Cycle
        /// Status set on a Penalty record when the penalty has been issued and posted to the Taxpayer's account but the PRN has not been generated yet.
        /// </summary>
        Posted,
        /// <summary>
        /// This is Status Number 2, or Number 3, or Number 4 in a Penalty's Life Cycle
        /// Status set on a Penalty record when the penalty has been reversed. It can be reversed before a PRN is generated, before it is Paid or after it is paid hence whey this could be Status Number 2 or 3 or 4
        /// </summary>
        Reversed
    }
}