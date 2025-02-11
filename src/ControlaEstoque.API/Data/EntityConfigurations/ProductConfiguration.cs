using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ControlaEstoque.API.Models;

namespace ControlaEstoque.API.Data.EntityConfigurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnType("varchar(36)");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.Stock)
            .IsRequired()
            .HasColumnType("smallint");

        builder.Property(e => e.Image)
            .HasMaxLength(500);
    }
}
