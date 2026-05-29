using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_Lecturas.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioEstadisticas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Estadisticas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estadisticas_UsuarioId",
                table: "Estadisticas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estadisticas_Usuarios_UsuarioId",
                table: "Estadisticas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estadisticas_Usuarios_UsuarioId",
                table: "Estadisticas");

            migrationBuilder.DropIndex(
                name: "IX_Estadisticas_UsuarioId",
                table: "Estadisticas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Estadisticas");
        }
    }
}
