using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_Lecturas.Migrations
{
    /// <inheritdoc />
    public partial class AgregarSinopsis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sinopsis",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sinopsis",
                table: "Libros");
        }
    }
}
