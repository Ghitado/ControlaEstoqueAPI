using ControlaEstoque.Domain.Repositories;
using ControlaEstoque.Domain.Repositories.Product;
using ControlaEstoque.Domain.Repositories.Sale;
using ControlaEstoque.Infrastructure.DataAccess;
using ControlaEstoque.Infrastructure.DataAccess.Repositories;
using ControlaEstoque.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControlaEstoque.Infrastructure
{
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

            services.AddScoped<IProductReadOnlyRepository, ProductRepository>();
            services.AddScoped<IProductWriteOnlyRepository, ProductRepository>();
            services.AddScoped<ISaleReadOnlyRepository, SaleRepository>();
            services.AddScoped<ISaleWriteOnlyRepository, SaleRepository>();
        }

        private static void AddDbContext_MySql(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));

            services.AddDbContext<ControlaEstoqueDbContext>(options =>
            {
                options.UseMySql(
                    connectionString,
                    serverVersion,
                    b => b.MigrationsAssembly(typeof(ControlaEstoqueDbContext).Assembly.FullName));
            });
        }
    }
}
