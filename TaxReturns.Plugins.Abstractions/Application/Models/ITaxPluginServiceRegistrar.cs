using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxReturns.Plugins.Abstractions.Application.Models
{
    public interface ITaxPluginServiceRegistrar
    {
        void RegisterServices(IServiceCollection services, IConfiguration configuration);
    }
}
