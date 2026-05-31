using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_Lecturas.Migrations
{
    /// <inheritdoc />
    public partial class Notas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibroId",
                table: "Notas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Notas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_LibroId",
                table: "Notas",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_UsuarioId",
                table: "Notas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Libros_LibroId",
                table: "Notas",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Usuarios_UsuarioId",
                table: "Notas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Libros_LibroId",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Usuarios_UsuarioId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_LibroId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_UsuarioId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Notas");
        }
    }
}
