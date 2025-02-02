using ControlaEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.Infrastructure.EntityConfigurations;
public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
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

        builder.HasOne(e => e.Sale)
            .WithMany(v => v.Items)
            .IsRequired();

        builder.HasOne(e => e.Product)
            .WithMany()
            .IsRequired();

    }
}

