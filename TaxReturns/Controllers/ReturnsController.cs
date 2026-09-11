using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaxReturns.Plugins.Abstractions.Application.Models.Enums;
using TaxReturns.Plugins.Abstractions.Application.Plugins;

namespace TaxReturns.Controllers
{
    [Route("api/{taxType}/returns")]
    [ApiController]
    public class ReturnsController : ControllerBase
    {
        private readonly IPluginResolver resolver;
        private readonly JsonSerializerOptions serializerOptions = new() { 
            PropertyNameCaseInsensitive = true
        };
        public ReturnsController(IPluginResolver resolver)
        {
            this.resolver = resolver;
        }
        [HttpPost("calculate")]
        public async Task<ActionResult> Calculate(TaxType taxType, JsonElement payload)
        {
            var plugin = resolver.Resolve<ITaxPlugin>(taxType);
            var request = payload.Deserialize(plugin.CalculationRequestType,serializerOptions);
            if(request is null)
            {
                return BadRequest();
            }
            var result = await plugin.CalculateTax(request);
            if (result.IsSuccess)
            {
                if (!plugin.TaxAssessmentType.IsInstanceOfType(result.Data)) {
                    return BadRequest();
                }
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> FileAsync(TaxType taxType,JsonElement payload,CancellationToken cancellationToken = default)
        {
            var plugin = resolver.Resolve<ITaxPlugin>(taxType);
            var request = payload.Deserialize(plugin.TaxReturnRequestType, serializerOptions);
            if(request is null)
            {
                return BadRequest();
            }
            var result = await plugin.ProcessReturn(request);
            if (result.IsSuccess)
            {
                if (!plugin.TaxReturnType.IsInstanceOfType(result.Data))
                {
                    return BadRequest();
                }
            }
            return Ok(result);
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
