using Microsoft.Extensions.DependencyInjection;
using TaxReturns.Plugins.Abstractions.Application.Models.Enums;
using TaxReturns.Plugins.Abstractions.Application.Plugins;

namespace TaxReturns.Plugins.Abstractions.Infrastructure
{
    public class PluginResolver : IPluginResolver
    {
        private readonly IServiceProvider service;
        public PluginResolver(IServiceProvider service)
        {
            this.service = service;
        }
        public T Resolve<T>(TaxType taxType) where T : ITaxCapability
        {
            var plugins = service.GetServices<T>();
            var plugin = plugins.FirstOrDefault(x => x.TaxType == taxType);
            return plugin ?? throw new KeyNotFoundException($"{typeof(T).Name} plugin for tax type {taxType} was not found");
        }
    }
}
