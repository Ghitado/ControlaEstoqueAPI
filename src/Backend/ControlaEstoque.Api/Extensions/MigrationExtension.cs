using ControlaEstoque.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.Api.Extensions;

public static class MigrationExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ControlaEstoqueDbContext context =
            scope.ServiceProvider.GetRequiredService<ControlaEstoqueDbContext>();

        context.Database.Migrate();
    }
}
