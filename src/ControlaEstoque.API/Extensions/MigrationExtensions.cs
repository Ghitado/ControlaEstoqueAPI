using ControlaEstoque.API.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.API.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ControlaEstoqueDbContext context =
            scope.ServiceProvider.GetRequiredService<ControlaEstoqueDbContext>();

        context.Database.Migrate();
    }
}
