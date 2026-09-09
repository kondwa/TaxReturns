using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxReturns.Application.Abstractions.Plugins;
using TaxReturns.Domain.Models;
using TaxReturns.Plugins.VAT.Contracts;

namespace TaxReturns.Controllers
{
    [Route("api/{taxType}/returns")]
    [ApiController]
    public class ReturnsController : ControllerBase
    {
        private readonly IPluginResolver resolver;
        public ReturnsController(IPluginResolver resolver)
        {
            this.resolver = resolver;
        }
        [HttpPost]
        public async Task<ActionResult> FileAsync(string taxType,VatFileReturnRequest request,CancellationToken cancellationToken = default)
        {
            var plugin =
            resolver.Resolve<IReturnPlugin<VatFileReturnResult,VatFileReturnRequest>>(taxType);

            var result =
                await plugin.FileAsync(
                    request,
                    cancellationToken);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult> List(string taxType,[FromQuery] ReturnQuery query, CancellationToken cancellationToken = default)
        {
            var plugin = resolver.Resolve<IReturnPlugin<VatFileReturnResult, VatFileReturnRequest>>(taxType);
            var result = await plugin.ListAsync(query, cancellationToken);
            return Ok(result);
        }
    }
}
