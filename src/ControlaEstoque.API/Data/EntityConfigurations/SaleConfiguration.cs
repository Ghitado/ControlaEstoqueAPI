using ControlaEstoque.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.API.Data.EntityConfigurations;
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

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.DateSale)
            .IsRequired()
            .HasColumnType("datetime");

        builder.HasMany(e => e.Items)
            .WithOne()
            .HasForeignKey(e => e.SaleId)
            .IsRequired();
    }
}


