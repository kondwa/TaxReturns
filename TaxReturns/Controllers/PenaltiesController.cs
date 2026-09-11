
using Microsoft.AspNetCore.Mvc;
using TaxReturns.Plugins.Abstractions.Application.Plugins;
using TaxReturns.Plugins.Abstractions.Application.Models.Enums;
using TaxReturns.Plugins.Abstractions.Application.Models.Inputs;

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
        public async Task<ActionResult> Calculate(TaxType taxType, CalculationRequest request,CancellationToken cancellationToken = default)
        {
            var plugin = resolver.Resolve<ITaxPlugin>(taxType);
            var result = await plugin.CalculateTax(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        [HttpGet]
        public async Task<ActionResult> List(TaxType taxType,[FromQuery] string tpin, CancellationToken cancellationToken = default)
        {
            var plugin = resolver.Resolve<ITaxPlugin>(taxType);
            var result = await plugin.ListReturns(tpin);
            return Ok(result);
        }
    }
    
}
