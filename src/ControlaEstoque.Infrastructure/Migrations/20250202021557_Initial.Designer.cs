﻿// <auto-generated />
using System;
using ControlaEstoque.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControlaEstoque.Infrastructure.Migrations
{
    [DbContext(typeof(ControlaEstoqueDbContext))]
    [Migration("20250202021557_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ControlaEstoque.Domain.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("Stock")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("ControlaEstoque.Domain.Entities.Sale", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Buyer")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DateSale")
                        .HasColumnType("datetime");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("Paid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("sales", (string)null);
                });

            modelBuilder.Entity("ControlaEstoque.Domain.Entities.SaleItem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<string>("SaleId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("sale_items", (string)null);
                });

            modelBuilder.Entity("ControlaEstoque.Domain.Entities.SaleItem", b =>
                {
                    b.HasOne("ControlaEstoque.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControlaEstoque.Domain.Entities.Sale", "Sale")
                        .WithMany("Items")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("ControlaEstoque.Domain.Entities.Sale", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
