using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TaxReturns.Application.Abstractions.Plugins;
using TaxReturns.Infrastructure;
using TaxReturns.Plugins.VAT.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(
    new AutofacServiceProviderFactory());

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VatDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaxReturnsDB"));
});

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

app.Run();

