using TaxReturns.Domain.Models;

namespace TaxReturns.Application.Abstractions.Plugins
{
    public interface IPenaltyPlugin<IResult, IRequest> : ITaxCapability
    {
        Task<IResult> LateFiling(IRequest request,CancellationToken cancellationToken = default);
        Task<IResult> LatePayment(IRequest request, CancellationToken cancellationToken = default);
        Task<IResult> GetById(Guid id, CancellationToken cancellationToken = default);
        Task<PagedResult<IResult>> List(PenaltyQuery request, CancellationToken cancellationToken = default);
    }
}
