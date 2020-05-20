using Microsoft.EntityFrameworkCore.Migrations;

namespace Ds.Data.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Notas_AlunoId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_DisciplinaId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_PeriodoId",
                table: "Notas");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_AlunoId",
                table: "Notas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_DisciplinaId",
                table: "Notas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_PeriodoId",
                table: "Notas",
                column: "PeriodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Notas_AlunoId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_DisciplinaId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_PeriodoId",
                table: "Notas");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_AlunoId",
                table: "Notas",
                column: "AlunoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_DisciplinaId",
                table: "Notas",
                column: "DisciplinaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_PeriodoId",
                table: "Notas",
                column: "PeriodoId",
                unique: true);
        }
    }
}
