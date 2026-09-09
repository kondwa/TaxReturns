using TaxReturns.Domain.Models;

namespace TaxReturns.Application.Abstractions.Plugins
{
    public interface IPaymentPlugin<IResult,IRequest> : ITaxCapability
    {
        Task InitiatePayment(PaymentRequest request, CancellationToken cancellationToken = default);
        Task PostSettlement(PostBackData data, CancellationToken cancellationToken = default);

        Task<IResult> ProcessPayment(IRequest request, CancellationToken cancellationToken = default);
    }
}
