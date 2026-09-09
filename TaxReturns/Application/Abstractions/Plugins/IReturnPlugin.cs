using TaxReturns.Domain.Models;

namespace TaxReturns.Application.Abstractions.Plugins
{
    public interface IReturnPlugin<IResult, IRequest> : ITaxCapability
    {
        Task<IResult> Calculate(IRequest request,CancellationToken cancellationToken=default);
        Task<IResult> FileAsync(IRequest request, CancellationToken cancellationToken = default);
        Task<IResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PagedResult<IResult>> ListAsync(ReturnQuery query, CancellationToken cancellationToken = default);


    }
}
