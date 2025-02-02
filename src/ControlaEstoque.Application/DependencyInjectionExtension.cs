using ControlaEstoque.Application.Interfaces;
using ControlaEstoque.Application.Mappings;
using ControlaEstoque.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ControlaEstoque.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddServices(services);
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped(typeof(ProductMapper));

        services.AddScoped<IProductService, ProductService>();
    }
}

