using ControlaEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.Infrastructure.DataAccess.EntityConfigurations;
public sealed class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("sale_items");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnType("varchar(36)");

        builder.Property(e => e.Quantity)
            .IsRequired()
            .HasColumnType("smallint");

        builder.Property(e => e.UnitPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Ignore(e => e.TotalPrice);

        builder.HasOne<Sale>()
            .WithMany(v => v.Items)
            .HasForeignKey(e => e.SaleId)
            .IsRequired();

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(e => e.ProductId)
            .IsRequired();
    }
}

