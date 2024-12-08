﻿// <auto-generated />
using DesafioRotasViagem.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioRotasViagem.Infra.Migrations
{
    [DbContext(typeof(RotasViagemContext))]
    [Migration("20241207233157_InicialCreate")]
    partial class InicialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("DesafioRotasViagem.Domain.Entities.Rota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Custo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rotas", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
