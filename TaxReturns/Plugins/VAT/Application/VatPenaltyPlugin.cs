using Microsoft.EntityFrameworkCore;
using TaxReturns.Application.Abstractions.Plugins;
using TaxReturns.Domain.Models;
using TaxReturns.Plugins.VAT.Contracts;
using TaxReturns.Plugins.VAT.Domain.Entities;
using TaxReturns.Plugins.VAT.Infrastructure.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TaxReturns.Plugins.VAT.Application
{
    public class VatPenaltyPlugin: IPenaltyPlugin<VatPenaltyResult, VatCalculatePenaltyRequest>
    {
        private readonly VatDbContext context;
        public VatPenaltyPlugin(VatDbContext context)
        {
            this.context = context;
        }
        public string TaxType => "VAT";

        private const decimal penaltyRate = 0.10m;

        public async Task<VatPenaltyResult> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<VatPenaltyResult> LateFiling(VatCalculatePenaltyRequest request, CancellationToken cancellationToken = default)
        {
            var penaltyAmount =
            request.OutstandingAmount * penaltyRate;

            var penalty = new VatPenalty(
                request.TaxpayerNumber,
                request.Period,
                request.OutstandingAmount,
                penaltyAmount,
                request.DaysLate);

            context.Penalties.Add(penalty);

            await context.SaveChangesAsync(
                cancellationToken);

            return new VatPenaltyResult(
                penalty.Id,
                TaxType,
                penalty.TaxpayerNumber,
                penalty.Period,
                penalty.OutstandingAmount,
                penalty.PenaltyAmount,
                penalty.DaysLate,
                penalty.CreatedAtUtc);
        }

        public Task<VatPenaltyResult> LatePayment(VatCalculatePenaltyRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<VatPenaltyResult>> List(PenaltyQuery request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
