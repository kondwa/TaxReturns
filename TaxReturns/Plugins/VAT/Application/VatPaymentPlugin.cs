using Microsoft.EntityFrameworkCore;
using TaxReturns.Application.Abstractions.Plugins;
using TaxReturns.Domain.Models;
using TaxReturns.Plugins.VAT.Contracts;
using TaxReturns.Plugins.VAT.Domain.Entities;
using TaxReturns.Plugins.VAT.Infrastructure.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TaxReturns.Plugins.VAT.Application
{
    public class VatPaymentPlugin : IPaymentPlugin<VatPaymentResult,VatProcessPaymentRequest>
    {
        private readonly VatDbContext context;

        public VatPaymentPlugin(VatDbContext context)
        {
            this.context = context;
        }
        public string TaxType => "VAT";

        public Task InitiatePayment(PaymentRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task PostSettlement(PostBackData data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<VatPaymentResult> ProcessPayment(VatProcessPaymentRequest request, CancellationToken cancellationToken = default)
        {
            var payment = new VatPayment(
            request.TaxpayerNumber,
            request.ReferenceNumber,
            request.Amount);

            context.Payments.Add(payment);

            await context.SaveChangesAsync(
                cancellationToken);

            return new VatPaymentResult(
                payment.Id,
                TaxType,
                payment.TaxpayerNumber,
                payment.ReferenceNumber,
                payment.Amount,
                payment.ReceivedAtUtc);
        }
    }
}
