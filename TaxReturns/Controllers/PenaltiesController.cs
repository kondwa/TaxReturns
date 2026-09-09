using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxReturns.Application.Abstractions.Plugins;
using TaxReturns.Domain.Models;
using TaxReturns.Plugins.VAT.Contracts;

namespace TaxReturns.Controllers
{
    [Route("api/{taxType}/penalties")]
    [ApiController]
    public class PenaltiesController : ControllerBase
    {
        private readonly IPluginResolver resolver;
        public PenaltiesController(IPluginResolver resolver)
        {
            this.resolver = resolver;
        }
        [HttpPost]
        public async Task<ActionResult> Calculate(string taxType, VatCalculatePenaltyRequest request,CancellationToken cancellationToken = default)
        {
            var plugin = resolver.Resolve<IPenaltyPlugin<VatPenaltyResult, VatCalculatePenaltyRequest>>(taxType);
            var result = await plugin.LateFiling(request, cancellationToken);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult> List(string taxType, PenaltyQuery query, CancellationToken cancellationToken = default)
        {
            var plugin = resolver.Resolve<IPenaltyPlugin<VatPenaltyResult, VatCalculatePenaltyRequest>>(taxType);
            var result = await plugin.List(query, cancellationToken);
            return Ok(result);
        }
    }
    
}
