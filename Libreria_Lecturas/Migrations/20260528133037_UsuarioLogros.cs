using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_Lecturas.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioLogros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Logros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logros_UsuarioId",
                table: "Logros",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logros_Usuarios_UsuarioId",
                table: "Logros",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logros_Usuarios_UsuarioId",
                table: "Logros");

            migrationBuilder.DropIndex(
                name: "IX_Logros_UsuarioId",
                table: "Logros");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Logros");
        }
    }
}
