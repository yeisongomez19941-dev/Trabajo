using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_Lecturas.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposHistorialLecturas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibroId",
                table: "HistorialLecturas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaginasLeidas",
                table: "HistorialLecturas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "HistorialLecturas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistorialLecturas_LibroId",
                table: "HistorialLecturas",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialLecturas_UsuarioId",
                table: "HistorialLecturas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialLecturas_Libros_LibroId",
                table: "HistorialLecturas",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialLecturas_Usuarios_UsuarioId",
                table: "HistorialLecturas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialLecturas_Libros_LibroId",
                table: "HistorialLecturas");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialLecturas_Usuarios_UsuarioId",
                table: "HistorialLecturas");

            migrationBuilder.DropIndex(
                name: "IX_HistorialLecturas_LibroId",
                table: "HistorialLecturas");

            migrationBuilder.DropIndex(
                name: "IX_HistorialLecturas_UsuarioId",
                table: "HistorialLecturas");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "HistorialLecturas");

            migrationBuilder.DropColumn(
                name: "PaginasLeidas",
                table: "HistorialLecturas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "HistorialLecturas");
        }
    }
}
