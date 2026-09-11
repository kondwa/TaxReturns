using TaxReturns.Plugins.Abstractions.Application.Models.Enums;

namespace TaxReturns.Plugins.Abstractions.Application.Plugins
{
    public interface IPluginResolver
    {
        T Resolve<T>(TaxType taxType)
        where T : ITaxCapability;
    }
}
