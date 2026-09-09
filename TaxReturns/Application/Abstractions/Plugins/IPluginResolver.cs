namespace TaxReturns.Application.Abstractions.Plugins
{
    public interface IPluginResolver
    {
        T Resolve<T>(string taxType)
        where T : ITaxCapability;
    }
}
