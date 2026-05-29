using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_Lecturas.Migrations
{
    /// <inheritdoc />
    public partial class RecomendacioUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibroId",
                table: "Recomendaciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Recomendaciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recomendaciones_LibroId",
                table: "Recomendaciones",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_Recomendaciones_UsuarioId",
                table: "Recomendaciones",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendaciones_Libros_LibroId",
                table: "Recomendaciones",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendaciones_Usuarios_UsuarioId",
                table: "Recomendaciones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recomendaciones_Libros_LibroId",
                table: "Recomendaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Recomendaciones_Usuarios_UsuarioId",
                table: "Recomendaciones");

            migrationBuilder.DropIndex(
                name: "IX_Recomendaciones_LibroId",
                table: "Recomendaciones");

            migrationBuilder.DropIndex(
                name: "IX_Recomendaciones_UsuarioId",
                table: "Recomendaciones");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "Recomendaciones");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Recomendaciones");
        }
    }
}
