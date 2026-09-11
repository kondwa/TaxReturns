using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaxReturns.Plugins.Abstractions.Infrastructure.Persistence;

namespace TaxReturns.Infrastructure.DependencyInjection
{
    public static class PluginDbContextExtensions
    {
        public static IServiceCollection AddPluginDbContexts(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
        {
            var connectionString =
                configuration.GetConnectionString("TaxReturnsDB") ?? throw new InvalidOperationException("TaxReturnsDB connection string was not found.");

            var contextTypes = assembly
                .GetTypes()
                .Where(type => !type.IsAbstract && typeof(TaxPluginDbContext).IsAssignableFrom(type));

            foreach (var contextType in contextTypes)
            {
                RegisterDbContext(services,contextType,connectionString);
            }

            return services;
        }

        private static void RegisterDbContext(
            IServiceCollection services,
            Type contextType,
            string connectionString)
        {
            var method = typeof(PluginDbContextExtensions)
                .GetMethod(
                    nameof(RegisterDbContextGeneric),
                    BindingFlags.Static |
                    BindingFlags.NonPublic)!
                .MakeGenericMethod(contextType);

            method.Invoke(
                null,
                [services, connectionString]);
        }

        private static void RegisterDbContextGeneric<TContext>(
            IServiceCollection services,
            string connectionString)
            where TContext : TaxPluginDbContext
        {
            services.AddDbContext<TContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
