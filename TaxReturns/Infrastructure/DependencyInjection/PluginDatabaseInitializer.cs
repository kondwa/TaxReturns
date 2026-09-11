using Microsoft.EntityFrameworkCore;
using TaxReturns.Plugins.Abstractions.Infrastructure.Persistence;

namespace TaxReturns.Infrastructure.DependencyInjection
{
    public static class PluginDatabaseInitializer
    {
        public static async Task InitialisePluginDatabasesAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();

            var serviceProvider = scope.ServiceProvider;

            var contextTypes = typeof(Program).Assembly.GetTypes()
                .Where(type => !type.IsAbstract && typeof(TaxPluginDbContext).IsAssignableFrom(type));

            foreach (var contextType in contextTypes)
            {
                var context = (DbContext)serviceProvider.GetRequiredService(contextType);
                await context.Database.MigrateAsync();
            }
        }
    }
}
