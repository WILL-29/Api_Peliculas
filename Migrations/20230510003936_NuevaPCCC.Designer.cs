﻿// <auto-generated />
using System;
using Api_Peliculas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiPeliculas.Migrations
{
    [DbContext(typeof(ApiPeliculasContext))]
    [Migration("20230510003936_NuevaPCCC")]
    partial class NuevaPCCC
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasKey("ID_Pelicula");

                    b.ToTable("Pelicula");
                });

            modelBuilder.Entity("Api_Peliculas.Model.Usuario", b =>
                {
                    b.Property<int>("ID_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Usuario"));

                    b.Property<string>("Nombre_Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Usuario");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
