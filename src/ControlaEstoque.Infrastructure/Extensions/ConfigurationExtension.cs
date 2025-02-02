using Microsoft.Extensions.Configuration;

namespace ControlaEstoque.Infrastructure.Extensions;
public static class ConfigurationExtension
{
    public static string ConnectionString(this IConfiguration configuration)
    {
        return configuration.GetConnectionString("MYSQL_DB_CONNECTION")!;
    }
}

