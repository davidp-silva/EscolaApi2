using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ds.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeDisciplina = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periodos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomePeriodo = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(250)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(50)", nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Telefone = table.Column<string>(type: "varchar(50)", nullable: true),
                    Discriminator = table.Column<string>(type: "varchar(100)", nullable: false),
                    Registro = table.Column<string>(type: "varchar(100)", nullable: true),
                    GrauParentesco = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeSerie = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosResponsaveis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AlunoId = table.Column<Guid>(nullable: false),
                    ResponsavelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosResponsaveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunosResponsaveis_Pessoal_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Pessoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlunosResponsaveis_Pessoal_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Pessoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    DisciplinaId = table.Column<Guid>(nullable: false),
                    AlunoId = table.Column<Guid>(nullable: false),
                    Presenca = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diarios_Pessoal_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Pessoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diarios_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaProfessores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProfessorId = table.Column<Guid>(nullable: false),
                    DisciplinaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaProfessores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplinaProfessores_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DisciplinaProfessores_Pessoal_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Pessoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PessoaId = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Pessoal_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ValorNota = table.Column<double>(nullable: false),
                    DisciplinaId = table.Column<Guid>(nullable: false),
                    PeriodoId = table.Column<Guid>(nullable: false),
                    AlunoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Pessoal_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Pessoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notas_Periodos_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "Periodos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeTurma = table.Column<string>(type: "varchar(200)", nullable: false),
                    SerieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TurmaDisciplinas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TurmaId = table.Column<Guid>(nullable: false),
                    DisciplinaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaDisciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurmaDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TurmaDisciplinas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TurmasAlunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TurmaId = table.Column<Guid>(nullable: false),
                    AlunoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmasAlunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurmasAlunos_Pessoal_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Pessoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TurmasAlunos_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosResponsaveis_AlunoId",
                table: "AlunosResponsaveis",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosResponsaveis_ResponsavelId",
                table: "AlunosResponsaveis",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Diarios_AlunoId",
                table: "Diarios",
                column: "AlunoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diarios_DisciplinaId",
                table: "Diarios",
                column: "DisciplinaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaProfessores_DisciplinaId",
                table: "DisciplinaProfessores",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaProfessores_ProfessorId",
                table: "DisciplinaProfessores",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaId",
                table: "Enderecos",
                column: "PessoaId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_TurmaDisciplinas_DisciplinaId",
                table: "TurmaDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaDisciplinas_TurmaId",
                table: "TurmaDisciplinas",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_SerieId",
                table: "Turmas",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_TurmasAlunos_AlunoId",
                table: "TurmasAlunos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_TurmasAlunos_TurmaId",
                table: "TurmasAlunos",
                column: "TurmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosResponsaveis");

            migrationBuilder.DropTable(
                name: "Diarios");

            migrationBuilder.DropTable(
                name: "DisciplinaProfessores");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "TurmaDisciplinas");

            migrationBuilder.DropTable(
                name: "TurmasAlunos");

            migrationBuilder.DropTable(
                name: "Periodos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Pessoal");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
