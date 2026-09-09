using Microsoft.EntityFrameworkCore;
using TaxReturns.Application.Abstractions.Plugins;
using TaxReturns.Domain.Models;
using TaxReturns.Plugins.VAT.Contracts;
using TaxReturns.Plugins.VAT.Domain.Entities;
using TaxReturns.Plugins.VAT.Infrastructure.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TaxReturns.Plugins.VAT.Application
{
    public class VatReturnPlugin:IReturnPlugin<VatFileReturnResult, VatFileReturnRequest>
    {
        private readonly VatDbContext context;
        private const decimal vatRate = 0.175m;

        public VatReturnPlugin(VatDbContext context)
        {
            this.context = context;
        }

        public string TaxType => "VAT";

        public async Task<VatFileReturnResult> Calculate(VatFileReturnRequest request, CancellationToken cancellationToken)
        {
            var taxPayable =
                request.TaxableAmount * vatRate;

            var vatReturn = new VatReturn(
                request.TaxpayerNumber,
                request.Period,
                request.TaxableAmount,
                taxPayable);
            return new VatFileReturnResult(
             vatReturn.Id,
             TaxType,
             vatReturn.TaxpayerNumber,
             vatReturn.Period,
             vatReturn.TaxableAmount,
             vatReturn.TaxPayable,
             vatReturn.FiledAtUtc);
        }

        public async Task<VatFileReturnResult> FileAsync(VatFileReturnRequest request,CancellationToken cancellationToken)
        {
            var taxPayable =
                request.TaxableAmount * vatRate;

            var vatReturn = new VatReturn(
                request.TaxpayerNumber,
                request.Period,
                request.TaxableAmount,
                taxPayable);

            context.Returns.Add(vatReturn);

            await context.SaveChangesAsync(
                cancellationToken);

            return new VatFileReturnResult(
                vatReturn.Id,
                TaxType,
                vatReturn.TaxpayerNumber,
                vatReturn.Period,
                vatReturn.TaxableAmount,
                vatReturn.TaxPayable,
                vatReturn.FiledAtUtc);
        }

        public async Task<VatFileReturnResult> GetByIdAsync(Guid id,CancellationToken cancellationToken)
        {
            var vatReturn = context.Returns.FirstOrDefault(x=>x.Id == id);
            if (vatReturn == null) throw new FileNotFoundException();
            return new VatFileReturnResult(
                vatReturn.Id,
                TaxType,
                vatReturn.TaxpayerNumber,
                vatReturn.Period,
                vatReturn.TaxableAmount,
                vatReturn.TaxPayable,
                vatReturn.FiledAtUtc);
        }

        public async Task<PagedResult<VatFileReturnResult>> ListAsync(ReturnQuery query, CancellationToken cancellationToken)
        {
            var listQuery = context.Returns.AsQueryable();
            var totalCount = listQuery.Count();
            if (!string.IsNullOrEmpty(query.Tpin))
            {
                listQuery = listQuery.Where(x => x.TaxpayerNumber == query.Tpin);
            }

            IReadOnlyList<VatFileReturnResult> items = listQuery.Select(vatReturn => new VatFileReturnResult(
                vatReturn.Id,
                TaxType,
                vatReturn.TaxpayerNumber,
                vatReturn.Period,
                vatReturn.TaxableAmount,
                vatReturn.TaxPayable,
                vatReturn.FiledAtUtc)).ToList();

            return new PagedResult<VatFileReturnResult>(items, query.Page, query.PageSize, totalCount);
            
        }
    }
}
