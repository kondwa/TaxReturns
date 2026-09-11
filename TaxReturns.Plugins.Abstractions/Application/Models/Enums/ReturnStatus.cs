namespace TaxReturns.Plugins.Abstractions.Application.Models.Enums
{
    public enum ReturnStatus
    {

        /// <summary>
        /// This is Status Number 2 in a Return's Life Cycle
        /// Status set on a return record when a PRN has been generated for that return and it is awaiting payment
        /// </summary>
        AwaitingPayment,
        /// <summary>
        /// This is Status Number 3 in a Return's Life Cycle
        /// Status set on a return record when the return has been paid for (the PRN that was attached to this return has been paid)
        /// </summary>
        Paid,
        /// <summary>
        /// This is Status Number 1 in a Return's Life Cycle
        /// Status set on a return record when it has been submitted (filed) and liability has been posted to Taxpayer's Account BUT PRN HAS NOT YET BEEN GENERATED.
        /// </summary>
        Submitted
    }
}