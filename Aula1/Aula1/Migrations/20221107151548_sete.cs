using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula1.Migrations
{
    public partial class sete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendamento",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "DuracaoEmHoras",
                table: "Agendamento");

            migrationBuilder.RenameTable(
                name: "Agendamento",
                newName: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "DuracaoEmMinutos",
                table: "Agendamentos",
                newName: "TipoDeAulaId");

            migrationBuilder.AddColumn<double>(
                name: "DuracaoHoras",
                table: "Agendamentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DuracaoMinutos",
                table: "Agendamentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TipoDeAula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeAula", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_TipoDeAulaId",
                table: "Agendamentos",
                column: "TipoDeAulaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_TipoDeAula_TipoDeAulaId",
                table: "Agendamentos",
                column: "TipoDeAulaId",
                principalTable: "TipoDeAula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_TipoDeAula_TipoDeAulaId",
                table: "Agendamentos");

            migrationBuilder.DropTable(
                name: "TipoDeAula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_TipoDeAulaId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "DuracaoHoras",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "DuracaoMinutos",
                table: "Agendamentos");

            migrationBuilder.RenameTable(
                name: "Agendamentos",
                newName: "Agendamento");

            migrationBuilder.RenameColumn(
                name: "TipoDeAulaId",
                table: "Agendamento",
                newName: "DuracaoEmMinutos");

            migrationBuilder.AddColumn<int>(
                name: "DuracaoEmHoras",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendamento",
                table: "Agendamento",
                column: "Id");
        }
    }
}
