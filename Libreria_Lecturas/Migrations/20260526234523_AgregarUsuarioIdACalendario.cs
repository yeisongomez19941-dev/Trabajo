using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_Lecturas.Migrations
{
    /// <inheritdoc />
    public partial class AgregarUsuarioIdACalendario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "CalendarioLecturas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalendarioLecturas_UsuarioId",
                table: "CalendarioLecturas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarioLecturas_Usuarios_UsuarioId",
                table: "CalendarioLecturas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarioLecturas_Usuarios_UsuarioId",
                table: "CalendarioLecturas");

            migrationBuilder.DropIndex(
                name: "IX_CalendarioLecturas_UsuarioId",
                table: "CalendarioLecturas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "CalendarioLecturas");
        }
    }
}
