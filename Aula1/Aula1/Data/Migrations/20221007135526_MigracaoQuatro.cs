using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula1.Data.Migrations
{
    public partial class MigracaoQuatro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmDestaque",
                table: "Cursos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmDestaque",
                table: "Cursos");
        }
    }
}
