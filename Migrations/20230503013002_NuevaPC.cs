using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPeliculas.Migrations
{
    /// <inheritdoc />
    public partial class NuevaPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pelicula_Categoria_categoriaID_Categoria",
                table: "Pelicula");

            migrationBuilder.DropIndex(
                name: "IX_Pelicula_categoriaID_Categoria",
                table: "Pelicula");

            migrationBuilder.DropColumn(
                name: "categoriaID_Categoria",
                table: "Pelicula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoriaID_Categoria",
                table: "Pelicula",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_categoriaID_Categoria",
                table: "Pelicula",
                column: "categoriaID_Categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Pelicula_Categoria_categoriaID_Categoria",
                table: "Pelicula",
                column: "categoriaID_Categoria",
                principalTable: "Categoria",
                principalColumn: "ID_Categoria");
        }
    }
}
