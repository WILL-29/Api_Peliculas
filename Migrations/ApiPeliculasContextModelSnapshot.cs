﻿// <auto-generated />
using System;
using Api_Peliculas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiPeliculas.Migrations
{
    [DbContext(typeof(ApiPeliculasContext))]
    partial class ApiPeliculasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api_Peliculas.Model.Categoria", b =>
                {
                    b.Property<int>("ID_Categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Categoria"));

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre_Cat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Categoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Api_Peliculas.Model.Pelicula", b =>
                {
                    b.Property<int>("ID_Pelicula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Pelicula"));

                    b.Property<int>("Clasificacion")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Pel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RutaImagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("categoriaID_Categoria")
                        .HasColumnType("int");

                    b.HasKey("ID_Pelicula");

                    b.HasIndex("categoriaID_Categoria");

                    b.ToTable("Pelicula");
                });

            modelBuilder.Entity("Api_Peliculas.Model.Pelicula", b =>
                {
                    b.HasOne("Api_Peliculas.Model.Categoria", "categoria")
                        .WithMany()
                        .HasForeignKey("categoriaID_Categoria");

                    b.Navigation("categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
