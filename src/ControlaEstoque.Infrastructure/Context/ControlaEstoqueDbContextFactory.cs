using ControlaEstoque.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ControlaEstoque.Infrastructure.Context;
public class ControlaEstoqueDbContextFactory : IDesignTimeDbContextFactory<ControlaEstoqueDbContext>
{
    public ControlaEstoqueDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "ControlaEstoque.API");

        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddUserSecrets<ControlaEstoqueDbContextFactory>()
        .Build();

        var builder = new DbContextOptionsBuilder<ControlaEstoqueDbContext>();
        var connectionString = ConfigurationExtension.ConnectionString(configuration);
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));
        
        builder.UseMySql(connectionString, serverVersion);

        return new ControlaEstoqueDbContext(builder.Options);
    }
}

