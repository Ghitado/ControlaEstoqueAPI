using ControlaEstoque.Application.Interfaces;
using ControlaEstoque.Application.Mappings;
using ControlaEstoque.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ControlaEstoque.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddServices(services);
        AddMediatRHandlers(services);
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped(typeof(ProductMapper));

        services.AddScoped<IProductService, ProductService>();
    }

    private static void AddMediatRHandlers(IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}

