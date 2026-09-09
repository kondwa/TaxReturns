using TaxReturns.Application.Abstractions.Plugins;

namespace TaxReturns.Infrastructure
{
    public class PluginResolver : IPluginResolver
    {
        private readonly IServiceProvider service;
        public PluginResolver(IServiceProvider service)
        {
            this.service = service;
        }
        public T Resolve<T>(string taxType) where T : ITaxCapability
        {
            var plugins = service.GetServices<T>();
            var plugin = plugins.FirstOrDefault(x => string.Equals(x.TaxType, taxType, StringComparison.OrdinalIgnoreCase));
            return plugin ?? throw new KeyNotFoundException($"{typeof(T).Name} plugin for tax type {taxType} was not found");
        }
    }
}
