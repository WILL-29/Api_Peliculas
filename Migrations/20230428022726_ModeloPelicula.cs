using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPeliculas.Migrations
{
    /// <inheritdoc />
    public partial class ModeloPelicula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    IDPelicula = table.Column<int>(name: "ID_Pelicula", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePel = table.Column<string>(name: "Nombre_Pel", type: "nvarchar(max)", nullable: true),
                    RutaImagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Clasificacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDCategoria = table.Column<int>(name: "ID_Categoria", type: "int", nullable: false),
                    categoriaIDCategoria = table.Column<int>(name: "categoriaID_Categoria", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.IDPelicula);
                    table.ForeignKey(
                        name: "FK_Pelicula_Categoria_categoriaID_Categoria",
                        column: x => x.categoriaIDCategoria,
                        principalTable: "Categoria",
                        principalColumn: "ID_Categoria");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_categoriaID_Categoria",
                table: "Pelicula",
                column: "categoriaID_Categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pelicula");
        }
    }
}
