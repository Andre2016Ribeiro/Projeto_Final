﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationBackendBotanica.Data;

#nullable disable

namespace WebApplicationBackendBotanica.Migrations
{
    [DbContext(typeof(WebApplicationBackendBotanicaContext))]
    partial class WebApplicationBackendBotanicaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClassBackendBotanica.Artigo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Artigo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaId = 1,
                            Nome = "Orquidias",
                            Preco = 0.5
                        },
                        new
                        {
                            Id = 2,
                            CategoriaId = 1,
                            Nome = "Margaridas",
                            Preco = 2.5
                        },
                        new
                        {
                            Id = 3,
                            CategoriaId = 2,
                            Nome = "Terra do Bosque",
                            Preco = 2.5
                        },
                        new
                        {
                            Id = 4,
                            CategoriaId = 2,
                            Nome = "Terra do campo",
                            Preco = 3.5
                        });
                });

            modelBuilder.Entity("ClassBackendBotanica.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Plantas"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Solo"
                        });
                });

            modelBuilder.Entity("ClassBackendBotanica.Encomenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtigoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEncomenda")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int?>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtigoId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Encomenda");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtigoId = 4,
                            DataEncomenda = new DateTime(2023, 9, 14, 22, 26, 45, 458, DateTimeKind.Local).AddTicks(2356),
                            Quantidade = 50,
                            UtilizadorId = 1
                        },
                        new
                        {
                            Id = 2,
                            ArtigoId = 1,
                            DataEncomenda = new DateTime(2023, 9, 14, 22, 26, 45, 458, DateTimeKind.Local).AddTicks(2418),
                            Quantidade = 40,
                            UtilizadorId = 1
                        },
                        new
                        {
                            Id = 3,
                            ArtigoId = 2,
                            DataEncomenda = new DateTime(2023, 9, 14, 22, 26, 45, 458, DateTimeKind.Local).AddTicks(2421),
                            Quantidade = 50,
                            UtilizadorId = 3
                        },
                        new
                        {
                            Id = 4,
                            ArtigoId = 3,
                            DataEncomenda = new DateTime(2023, 9, 14, 22, 26, 45, 458, DateTimeKind.Local).AddTicks(2423),
                            Quantidade = 30,
                            UtilizadorId = 2
                        });
                });

            modelBuilder.Entity("ClassBackendBotanica.Utilizador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utilizador");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Morada = " Rua 11",
                            Nome = "ze Pintas",
                            Pass = "a",
                            UserName = "zepin"
                        },
                        new
                        {
                            Id = 2,
                            Morada = " Rua 12",
                            Nome = "Maria Calas Pintas",
                            Pass = "a",
                            UserName = "macalas"
                        },
                        new
                        {
                            Id = 3,
                            Morada = " Rua 31",
                            Nome = "Jose oliveira",
                            Pass = "a",
                            UserName = "zeo"
                        },
                        new
                        {
                            Id = 4,
                            Morada = " Rua 14",
                            Nome = "jonana souzas",
                            Pass = "a",
                            UserName = "jasou"
                        });
                });

            modelBuilder.Entity("ClassBackendBotanica.Artigo", b =>
                {
                    b.HasOne("ClassBackendBotanica.Categoria", "Categoria")
                        .WithMany("Artigos")
                        .HasForeignKey("CategoriaId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ClassBackendBotanica.Encomenda", b =>
                {
                    b.HasOne("ClassBackendBotanica.Artigo", "Artigo")
                        .WithMany("Encomendas")
                        .HasForeignKey("ArtigoId");

                    b.HasOne("ClassBackendBotanica.Utilizador", "Utilizador")
                        .WithMany("Encomendas")
                        .HasForeignKey("UtilizadorId");

                    b.Navigation("Artigo");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("ClassBackendBotanica.Artigo", b =>
                {
                    b.Navigation("Encomendas");
                });

            modelBuilder.Entity("ClassBackendBotanica.Categoria", b =>
                {
                    b.Navigation("Artigos");
                });

            modelBuilder.Entity("ClassBackendBotanica.Utilizador", b =>
                {
                    b.Navigation("Encomendas");
                });
#pragma warning restore 612, 618
        }
    }
}
