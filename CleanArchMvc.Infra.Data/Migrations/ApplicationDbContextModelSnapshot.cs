// <auto-generated />
using System;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("CleanArchMvc.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("Idade")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("98a64dcb-d599-4201-8a80-82b8cd99e31d"),
                            Idade = 15L,
                            Name = "Joao Luz da Silva"
                        },
                        new
                        {
                            Id = new Guid("17e559a5-adf8-4daa-bb50-97b40bfaf4a2"),
                            Idade = 25L,
                            Name = "Maria Ivotete Costa"
                        },
                        new
                        {
                            Id = new Guid("268f5aae-0cc4-47fb-8793-ecaf658fffdf"),
                            Idade = 39L,
                            Name = "Aderbaldo Oliveira Souza"
                        },
                        new
                        {
                            Id = new Guid("46626c40-72ff-42f8-921e-7ffa0c2cea88"),
                            Idade = 42L,
                            Name = "Romarildo de Alencar Silveira"
                        },
                        new
                        {
                            Id = new Guid("7d56fe8c-5223-4a9a-a962-7ce162aa23b6"),
                            Idade = 32L,
                            Name = "Joana da Silva Pereira"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
