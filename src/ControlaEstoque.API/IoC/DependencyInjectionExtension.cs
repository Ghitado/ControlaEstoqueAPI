using ControlaEstoque.API.Data.Context;
using ControlaEstoque.API.Repositories.Product;
using ControlaEstoque.API.Repositories.Sale;
using ControlaEstoque.API.Services.Product;
using ControlaEstoque.API.Services.Sale;
using ControlaEstoque.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.API.IoC;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext_MySql(services, configuration);
        AddRepositories(services);
    }
    public static void AddApplication(this IServiceCollection services)
    {
        AddServices(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
    }

    private static void AddDbContext_MySql(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.ConnectionString();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));

        services.AddDbContext<ControlaEstoqueDbContext>(options =>
        {
            options.UseMySql(
                connectionString,
                serverVersion/*, 
                b => b.MigrationsAssembly(typeof(ControlaEstoqueDbContext).Assembly.FullName)*/);
        });
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ISaleService, SaleService>();
    }

}
