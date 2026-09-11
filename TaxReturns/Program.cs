using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TaxReturns.Plugins.Abstractions.Infrastructure;
using TaxReturns.Plugins.Abstractions.Application.Plugins;
using System.Reflection;
using TaxReturns.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(
    new AutofacServiceProviderFactory());

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddPluginDbContexts(builder.Configuration, typeof(Program).Assembly);

builder.Host.ConfigureContainer<ContainerBuilder>(container => {
    var assembly = typeof(Program).Assembly;

    container.RegisterAssemblyTypes(assembly)
        .AssignableTo<ITaxCapability>()
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    
    container.RegisterType<PluginResolver>()
        .As<IPluginResolver>()
        .InstancePerLifetimeScope();
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    //await app.InitialisePluginDatabasesAsync();
}

app.Run();

