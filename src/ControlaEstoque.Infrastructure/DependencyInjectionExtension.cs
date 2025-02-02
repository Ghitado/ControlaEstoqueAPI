using ControlaEstoque.Domain.Interfaces;
using ControlaEstoque.Domain.Interfaces.Product;
using ControlaEstoque.Domain.Interfaces.Sale;
using ControlaEstoque.Infrastructure.Context;
using ControlaEstoque.Infrastructure.Extensions;
using ControlaEstoque.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControlaEstoque.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext_MySql(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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

}

