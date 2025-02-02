using ControlaEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.Infrastructure.EntityConfigurations;
public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("sales");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnType("varchar(36)")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Buyer)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Paid)
            .IsRequired()
            .HasColumnType("tinyint(1)")
            .HasDefaultValue(0);

        builder.Property(e => e.Observations)
            .HasMaxLength(500);

        builder.Property(e => e.DateSale)
            .IsRequired()
            .HasColumnType("datetime");

        builder.HasMany(e => e.Items)
            .WithOne(e => e.Sale)
            .IsRequired();
    }
}


