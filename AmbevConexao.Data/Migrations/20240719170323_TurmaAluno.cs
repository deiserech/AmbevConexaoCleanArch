using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmbevConexao.Data.Migrations
{
    /// <inheritdoc />
    public partial class TurmaAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TurmaAluno",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    IdTurma = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaAluno", x => new { x.IdTurma, x.IdAluno });
                    table.ForeignKey(
                        name: "FK_TurmaAluno_Aluno_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmaAluno_Turma_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TurmaAluno_IdAluno",
                table: "TurmaAluno",
                column: "IdAluno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurmaAluno");
        }
    }
}
