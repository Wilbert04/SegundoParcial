using Microsoft.EntityFrameworkCore.Migrations;

namespace SegundoParcial.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "llamada",
                columns: table => new
                {
                    LlamadaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_llamada", x => x.LlamadaId);
                });

            migrationBuilder.CreateTable(
                name: "LlamadaDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Problema = table.Column<string>(nullable: true),
                    Solucion = table.Column<string>(nullable: true),
                    LLamadaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlamadaDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LlamadaDetalle_llamada_LLamadaid",
                        column: x => x.LLamadaid,
                        principalTable: "llamada",
                        principalColumn: "LlamadaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LlamadaDetalle_LLamadaid",
                table: "LlamadaDetalle",
                column: "LLamadaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LlamadaDetalle");

            migrationBuilder.DropTable(
                name: "llamada");
        }
    }
}
